using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Reserva
{
    public class GetReservaByIdQuery : IRequest<ReservaDTO>
    {
        public int Id { get; set; }
    }
}
