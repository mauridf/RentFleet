using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByTipoQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Tipo { get; set; }
    }
}
