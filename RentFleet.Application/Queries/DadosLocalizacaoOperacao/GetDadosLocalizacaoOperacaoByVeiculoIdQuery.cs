using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosLocalizacaoOperacao
{
    public class GetDadosLocalizacaoOperacaoByVeiculoIdQuery : IRequest<DadosLocalizacaoOperacaoDTO>
    {
        public int VeiculoId { get; set; }
    }
}
