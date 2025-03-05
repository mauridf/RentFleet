using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosLocalizacaoOperacao
{
    public class GetDadosLocalizacaoOperacaoByIdQuery : IRequest<DadosLocalizacaoOperacaoDTO>
    {
        public int Id { get; set; }
    }
}
