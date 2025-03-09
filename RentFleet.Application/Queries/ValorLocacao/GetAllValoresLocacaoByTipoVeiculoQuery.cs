using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.ValorLocacao
{
    public class GetAllValoresLocacaoByTipoVeiculoQuery : IRequest<IEnumerable<ValorLocacaoDTO>>
    {
        public string TipoVeiculo {  get; set; }
    }
}
