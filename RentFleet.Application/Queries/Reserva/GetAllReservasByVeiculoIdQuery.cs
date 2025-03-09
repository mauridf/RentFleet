using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Reserva
{
    public class GetAllReservasByVeiculoIdQuery : IRequest<IEnumerable<ReservaDTO>>
    {
        public int VeiculoId { get; set; }
    }
}
