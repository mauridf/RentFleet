using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
    }
}
