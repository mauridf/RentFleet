using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetVeiculoByChassiQuery : IRequest<VeiculoDTO>
    {
        public string Chassi { get; set; }
    }
}
