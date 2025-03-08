using MediatR;

namespace RentFleet.Application.Commands.ManutencaoVeiculo
{
    public class DeleteManutencaoVeiculoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
