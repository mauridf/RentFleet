using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByCorQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Cor {  get; set; }
    }
}
