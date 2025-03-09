using MediatR;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class DeleteLocacaoVeiculoCommandHandler : IRequestHandler<DeleteLocacaoVeiculoCommand>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;

        public DeleteLocacaoVeiculoCommandHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
        }

        public async Task<Unit> Handle(DeleteLocacaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo Locação ID: {Id}.", request.Id);

                var locacao = await _locacaoVeiculoRepository.GetByIdAsync(request.Id);
                if (locacao == null)
                {
                    log.Warning("Locação {Id} não encontrada.", request.Id);
                    throw new Exception("Locação não encontrada.");
                }

                await _locacaoVeiculoRepository.DeleteAsync(request.Id);

                log.Information("Locação {Id} excluída com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir Locação ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
