using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Reserva
{
    public class GetAllReservasByClienteIdQuery : IRequest<IEnumerable<ReservaDTO>>
    {
        public int ClienteId { get; set; }
    }
}
