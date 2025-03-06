using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosSegurancaConformidade
{
    public class GetDadosSegurancaConformidadeByVeiculoIdQuery : IRequest<DadosSegurancaConformidadeDTO>
    {
        public int VeiculoId { get; set; }
    }
}
