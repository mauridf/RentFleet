using MediatR;

namespace RentFleet.Application.Commands.Reserva
{
    public class DeleteReservaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
