using MediatR;

namespace RentFleet.Application.Commands.Clientes
{
    public class DeleteClienteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
