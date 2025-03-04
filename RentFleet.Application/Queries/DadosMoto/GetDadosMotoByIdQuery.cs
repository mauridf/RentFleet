using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosMoto
{
    public class GetDadosMotoByIdQuery : IRequest<DadosMotoDTO>
    {
        public int Id { get; set; }
    }
}
