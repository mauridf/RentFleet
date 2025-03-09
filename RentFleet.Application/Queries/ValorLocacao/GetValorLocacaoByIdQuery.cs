using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.ValorLocacao
{
    public class GetValorLocacaoByIdQuery : IRequest<ValorLocacaoDTO>
    {
        public int Id { get; set; }
    }
}
