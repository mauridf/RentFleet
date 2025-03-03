using MediatR;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class DeleteVeiculoCommandHandler : IRequestHandler<DeleteVeiculoCommand>
    {
        private IVeiculoRepository _veiculoRepository;

        public DeleteVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Unit> Handle(DeleteVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo veiculo com ID: {VeiculoId}.", request.Id);

                var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);
                if (veiculo == null)
                {
                    log.Warning("Veiculo com ID {VeiculoId} não encontrado.", request.Id);
                    throw new Exception("Veículo não encontrado.");
                }

                await _veiculoRepository.DeleteAsync(request.Id);

                log.Information("Veículo {VeiculoId} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir veículo com ID: {VeiculoId}.", request.Id);
                throw;
            }
        }
    }
}
