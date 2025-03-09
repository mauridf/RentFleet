using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Reserva;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class GetAllReservasByClienteIdQueryHandler : IRequestHandler<GetAllReservasByClienteIdQuery, IEnumerable<ReservaDTO>>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public GetAllReservasByClienteIdQueryHandler(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservaDTO>> Handle(GetAllReservasByClienteIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.ClienteId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as reservas por Cliente.", request.ClienteId);

                var reservas = await _reservaRepository.GetAllByClienteIdAsync(request.ClienteId);
                if (reservas == null)
                {
                    log.Warning("Nenhuma reserva do Cliente {ClienteId} foi encontrada.", request.ClienteId);
                    throw new Exception("Nenhuma reserva do Cliente foi encontrada.");
                }
                log.Information("Todos as reservas do Cliente {ClienteId} foram encontradas.", request.ClienteId);
                return _mapper.Map<IEnumerable<ReservaDTO>>(reservas);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as reservas do cliente {ClienteId}.", request.ClienteId);
                throw;
            }
        }
    }
}
