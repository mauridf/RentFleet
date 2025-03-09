using MediatR;

namespace RentFleet.Application.Commands.LocacaoVeiculo
{
    public class DeleteLocacaoVeiculoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
