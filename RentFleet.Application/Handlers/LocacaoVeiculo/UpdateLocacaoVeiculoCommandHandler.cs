using MediatR;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class UpdateLocacaoVeiculoCommandHandler : IRequestHandler<UpdateLocacaoVeiculoCommand,Unit>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;

        public UpdateLocacaoVeiculoCommandHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
        }

        public async Task<Unit> Handle(UpdateLocacaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando a Locação : {Id}.", request.Id);

                var locacao = await _locacaoVeiculoRepository.GetByIdAsync(request.Id);
                if (locacao == null)
                    throw new Exception("Locação não encontrado.");

                locacao.VeiculoId = request.VeiculoId;
                locacao.ClienteId = request.ClienteId;
                locacao.DataInicio = request.DataInicio;
                locacao.DataFim = request.DataFim;
                locacao.ValorBase = request.ValorBase;
                locacao.Desconto = request.Desconto;
                locacao.Juros = request.Juros;
                locacao.ValorTotal = request.ValorTotal;
                locacao.StatusLocacao = request.StatusLocacao;
                locacao.QuilometragemInicial = request.QuilometragemInicial;
                locacao.QuilometragemFinal = request.QuilometragemFinal;
                locacao.DataDevolucao = request.DataDevolucao;
                locacao.Observacoes = request.Observacoes;

                await _locacaoVeiculoRepository.UpdateAsync(locacao);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Locação {Id} editada com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar Locação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
