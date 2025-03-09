using MediatR;
using RentFleet.Application.Commands.Reserva;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class DeleteReservaCommandHandler : IRequestHandler<DeleteReservaCommand>
    {
        private readonly IReservaRepository _reservaRepository;

        public DeleteReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Unit> Handle(DeleteReservaCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo Reserva ID: {Id}.", request.Id);

                var reserva = await _reservaRepository.GetByIdAsync(request.Id);
                if (reserva == null)
                {
                    log.Warning("Reserva {Id} não encontrada.", request.Id);
                    throw new Exception("Reserva não encontrada.");
                }

                await _reservaRepository.DeleteAsync(request.Id);

                log.Information("Reserva {Id} excluída com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir Reserva ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
