using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosCaminhao
{
    public class GetDadosCaminhaoByVeiculoIdQuery : IRequest<DadosCaminhaoDTO>
    {
        public int VeiculoId { get; set; }
    }
}
