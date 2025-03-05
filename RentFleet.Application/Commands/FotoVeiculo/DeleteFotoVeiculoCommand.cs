using MediatR;

namespace RentFleet.Application.Commands.FotoVeiculo
{
    public class DeleteFotoVeiculoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
