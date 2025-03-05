using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.FotoVeiculo
{
    public class GetFotoVeiculoByVeiculoIdQuery : IRequest<List<FotoVeiculoDTO>>
    {
        public int VeiculoId { get; set; }
    }
}
