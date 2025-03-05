using MediatR;

namespace RentFleet.Application.Commands.FotoVeiculo
{
    public class UpdateFotoVeiculoCommand : IRequest
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public string UrlImagem { get; set; }
    }
}
