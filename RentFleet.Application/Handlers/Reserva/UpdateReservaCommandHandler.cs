using MediatR;
using RentFleet.Application.Commands.Reserva;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class UpdateReservaCommandHandler : IRequestHandler<UpdateReservaCommand, Unit>
    {
        private readonly IReservaRepository _reservaRepository;

        public UpdateReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Unit> Handle(UpdateReservaCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando a Reserva : {Id}.", request.Id);

                var reserva = await _reservaRepository.GetByIdAsync(request.Id);
                if (reserva == null)
                    throw new Exception("Reserva não encontrado.");

                reserva.VeiculoId = request.VeiculoId;
                reserva.ClienteId = request.ClienteId;
                reserva.DataReserva = request.DataReserva;
                reserva.DataReserva = request.DataInicio;
                reserva.DataFim = request.DataFim;
                reserva.StatusReserva = request.StatusReserva;

                await _reservaRepository.UpdateAsync(reserva);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Reserva {Id} editada com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar Reserva: {Id}.", request.Id);
                throw;
            }
        }
    }
}
