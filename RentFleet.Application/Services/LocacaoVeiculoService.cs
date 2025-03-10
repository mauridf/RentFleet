using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;
using RentFleet.Domain.Interfaces;

namespace RentFleet.Application.Services
{
    public class LocacaoVeiculoService
    {
        private readonly ILocacaoVeiculoRepository _locacaoRepository;
        private readonly IValorLocacaoRepository _valorLocacaoRepository;
        private readonly IRegraDescontoJurosRepository _regraDescontoJurosRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public LocacaoVeiculoService(
            ILocacaoVeiculoRepository locacaoRepository,
            IValorLocacaoRepository valorLocacaoRepository,
            IRegraDescontoJurosRepository regraDescontoJurosRepository,
            IVeiculoRepository veiculoRepository)
        {
            _locacaoRepository = locacaoRepository;
            _valorLocacaoRepository = valorLocacaoRepository;
            _regraDescontoJurosRepository = regraDescontoJurosRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<int> CriarLocacao(CreateLocacaoVeiculoCommand command)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(command.VeiculoId);
            if (veiculo == null) throw new Exception("❌ Veículo não encontrado.");

            // 🚨 Verificar se o veículo já está locado
            var locacaoAtiva = await _locacaoRepository.GetLocacaoAtivaPorVeiculo(command.VeiculoId);
            if (locacaoAtiva != null)
                throw new Exception("❌ O veículo já está locado e não pode ser alugado novamente no momento.");

            var ultimaLocacao = await _locacaoRepository.GetUltimaLocacaoPorVeiculo(command.VeiculoId);
            var quilometragemInicial = ultimaLocacao?.QuilometragemFinal ?? command.QuilometragemInicial;
            var quilometragemFinal = quilometragemInicial;

            // 🔍 Buscar valor da diária
            var valorDiaria = await _valorLocacaoRepository.GetByTipoCategoriaAsync(veiculo.Tipo, veiculo.Categoria);
            if (valorDiaria == null)
            {
                Console.WriteLine("⚠️ Aviso: Não há valor de locação cadastrado para este veículo. Assumindo R$ 0.00.");
            }

            decimal valorBaseDiaria = valorDiaria?.ValorDiaria ?? 0;
            var totalDias = (command.DataFim - command.DataInicio).Days;
            var valorBase = valorBaseDiaria * totalDias;

            var locacao = new LocacaoVeiculo
            {
                VeiculoId = command.VeiculoId,
                ClienteId = command.ClienteId,
                DataInicio = command.DataInicio,
                DataFim = command.DataFim,
                ValorBase = valorBase,
                Desconto = 0,
                Juros = 0,
                ValorTotal = valorBase,
                StatusLocacao = StatusLocacao.Ativa,
                QuilometragemInicial = quilometragemInicial,
                QuilometragemFinal = quilometragemFinal,
                DataDevolucao = command.DataFim,
                Observacoes = command.Observacoes
            };

            await _locacaoRepository.AddAsync(locacao);
            return locacao.Id;
        }

        public async Task AtualizarLocacao(UpdateLocacaoVeiculoCommand command)
        {
            var locacao = await _locacaoRepository.GetByIdAsync(command.Id);
            if (locacao == null) throw new Exception("❌ Locação não encontrada.");

            locacao.QuilometragemFinal = command.QuilometragemFinal;
            locacao.DataDevolucao = DateTime.UtcNow;

            var veiculo = await _veiculoRepository.GetByIdAsync(locacao.VeiculoId);
            var regra = await _regraDescontoJurosRepository.GetByTipoCategoriaAsync(veiculo.Tipo, veiculo.Categoria);

            if (locacao.DataDevolucao < locacao.DataFim)
            {
                locacao.Desconto = (regra?.Percentual ?? 0) * locacao.ValorBase / 100;
                locacao.ValorTotal = locacao.ValorBase - locacao.Desconto;
            }
            else if (locacao.DataDevolucao > locacao.DataFim)
            {
                locacao.Juros = (regra?.Percentual ?? 0) * locacao.ValorBase / 100;
                locacao.ValorTotal = locacao.ValorBase + locacao.Juros;
            }

            locacao.StatusLocacao = StatusLocacao.Finalizada;

            await _locacaoRepository.UpdateAsync(locacao);
        }
    }
}