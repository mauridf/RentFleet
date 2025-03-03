using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByNumeroPortasQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public int NumeroPortas { get; set; }
    }
}
