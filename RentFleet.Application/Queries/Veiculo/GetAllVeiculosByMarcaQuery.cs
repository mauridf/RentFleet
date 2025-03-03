using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByMarcaQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Marca { get; set; }
    }
}
