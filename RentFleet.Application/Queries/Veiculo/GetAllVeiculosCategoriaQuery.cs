using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosCategoriaQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Categoria { get; set; }
    }
}
