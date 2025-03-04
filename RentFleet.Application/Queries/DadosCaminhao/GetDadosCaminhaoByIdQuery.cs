using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosCaminhao
{
    public class GetDadosCaminhaoByIdQuery : IRequest<DadosCaminhaoDTO>
    {
        public int Id { get; set; }
    }
}
