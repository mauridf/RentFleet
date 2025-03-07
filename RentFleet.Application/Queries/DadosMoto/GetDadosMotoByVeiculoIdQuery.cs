using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosMoto
{
    public class GetDadosMotoByVeiculoIdQuery : IRequest<DadosMotoDTO>
    {
        public int VeiculoId { get; set; }
    }
}
