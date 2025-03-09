using MediatR;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class CreateLocacaoVeiculoCommandHandler : IRequestHandler<CreateLocacaoVeiculoCommand, int>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;

        public CreateLocacaoVeiculoCommandHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
        }

        public async Task<int> Handle(CreateLocacaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando Locação para o Veículo: {VeiculoId}.", request.VeiculoId);

                var locacao = new RentFleet.Domain.Entities.LocacaoVeiculo
                {
                    VeiculoId = request.VeiculoId,
                    ClienteId = request.ClienteId,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    ValorBase = request.ValorBase,
                    Desconto = request.Desconto,
                    Juros = request.Juros,
                    ValorTotal = request.ValorTotal,
                    StatusLocacao = request.StatusLocacao,
                    QuilometragemInicial = request.QuilometragemInicial,
                    QuilometragemFinal = request.QuilometragemFinal,
                    DataDevolucao = request.DataDevolucao,
                    Observacoes = request.Observacoes
                };

                await _locacaoVeiculoRepository.AddAsync(locacao);

                log.Information("Locação para o Veiculo {VeiculoId} inserido com sucesso. ID: {Id}.", request.VeiculoId, locacao.Id);
                return locacao.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao inserir locação para o veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
