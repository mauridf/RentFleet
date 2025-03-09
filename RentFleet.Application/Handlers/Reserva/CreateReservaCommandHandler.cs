using MediatR;
using RentFleet.Application.Commands.Reserva;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class CreateReservaCommandHandler : IRequestHandler<CreateReservaCommand, int>
    {
        private readonly IReservaRepository _reservaRepository;

        public CreateReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<int> Handle(CreateReservaCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando Reserva para o Veículo: {VeiculoId}.", request.VeiculoId);

                var reserva = new RentFleet.Domain.Entities.Reserva
                {
                    VeiculoId = request.VeiculoId,
                    ClienteId = request.ClienteId,
                    DataReserva = request.DataReserva,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    StatusReserva = request.StatusReserva
                };

                await _reservaRepository.AddAsync(reserva);

                log.Information("Reserva para o Veiculo {VeiculoId} inserido com sucesso. ID: {Id}.", request.VeiculoId, reserva.Id);
                return reserva.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao inserir reserva para o veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
