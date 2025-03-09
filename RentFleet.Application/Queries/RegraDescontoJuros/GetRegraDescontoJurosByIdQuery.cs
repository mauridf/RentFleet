using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.RegraDescontoJuros
{
    public class GetRegraDescontoJurosByIdQuery : IRequest<RegraDescontoJurosDTO>
    {
        public int Id { get; set; }
    }
}
