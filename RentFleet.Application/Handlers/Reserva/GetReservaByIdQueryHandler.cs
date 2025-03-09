using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Reserva;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Reserva
{
    public class GetReservaByIdQueryHandler : IRequestHandler<GetReservaByIdQuery, ReservaDTO>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public GetReservaByIdQueryHandler(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task<ReservaDTO> Handle(GetReservaByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Reserva", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Reserva: {Id}.", request.Id);

                var reserva = await _reservaRepository.GetByIdAsync(request.Id);
                if (reserva == null)
                {
                    log.Warning("Reserva {Id} não encontrada.", request.Id);
                    throw new Exception("Reserva não encontrada.");
                }

                log.Information("Reserva {Id} encontrada com sucesso.", request.Id);

                var reservaDTO = _mapper.Map<ReservaDTO>(reserva);
                log.Information("Mapeamento concluído com sucesso para reserva {Id}.", request.Id);

                return reservaDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar reserva: {Id}.", request.Id);
                throw;
            }
        }
    }
}
