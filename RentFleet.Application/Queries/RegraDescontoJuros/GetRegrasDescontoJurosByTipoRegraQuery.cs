using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.RegraDescontoJuros
{
    public class GetRegrasDescontoJurosByTipoRegraQuery : IRequest<IEnumerable<RegraDescontoJurosDTO>>
    {
        public string TipoRegra {  get; set; }
    }
}
