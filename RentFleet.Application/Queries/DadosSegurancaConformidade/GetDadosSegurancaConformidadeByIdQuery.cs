using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosSegurancaConformidade
{
    public class GetDadosSegurancaConformidadeByIdQuery : IRequest<DadosSegurancaConformidadeDTO>
    {
        public int Id { get; set; }
    }
}
