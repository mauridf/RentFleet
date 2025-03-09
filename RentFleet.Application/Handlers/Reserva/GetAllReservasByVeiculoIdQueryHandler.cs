using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Reserva;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class GetAllReservasByVeiculoIdQueryHandler : IRequestHandler<GetAllReservasByVeiculoIdQuery, IEnumerable<ReservaDTO>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public GetAllReservasByVeiculoIdQueryHandler(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservaDTO>> Handle(GetAllReservasByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as reservas por Veículo.", request.VeiculoId);

                var reservas = await _reservaRepository.GetAllByVeiculoIdAsync(request.VeiculoId);
                if (reservas == null)
                {
                    log.Warning("Nenhuma reserva do Veiculo {VeiculoId} foi encontrada.", request.VeiculoId);
                    throw new Exception("Nenhuma reserva do Veículo foi encontrada.");
                }
                log.Information("Todos as reservas do Veículo {VeiculoId} foram encontradas.", request.VeiculoId);
                return _mapper.Map<IEnumerable<ReservaDTO>>(reservas);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as reservas do veículo {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
