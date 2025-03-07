using MediatR;

namespace RentFleet.Application.Commands.DadosTecnicosVeiculo
{
    public class DeleteDadosTecnicosVeiculoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
