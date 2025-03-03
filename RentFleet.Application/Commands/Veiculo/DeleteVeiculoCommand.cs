using MediatR;

namespace RentFleet.Application.Commands.Veiculo
{
    public class DeleteVeiculoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
