using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByAnoFabricacaoModeloQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
    }
}
