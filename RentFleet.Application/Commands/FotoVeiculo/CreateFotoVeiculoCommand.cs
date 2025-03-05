using MediatR;

namespace RentFleet.Application.Commands.FotoVeiculo
{
    public class CreateFotoVeiculoCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        public string UrlImagem { get; set; }
    }
}
