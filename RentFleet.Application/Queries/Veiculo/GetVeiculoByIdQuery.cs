using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetVeiculoByIdQuery : IRequest<VeiculoDTO>
    {
        public int Id { get; set; }
    }
}
