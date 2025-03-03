using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByModeloQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Modelo { get; set; }
    }
}
