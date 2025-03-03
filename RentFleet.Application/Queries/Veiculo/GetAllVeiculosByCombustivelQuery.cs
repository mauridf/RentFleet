using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetAllVeiculosByCombustivelQuery : IRequest<IEnumerable<VeiculoDTO>>
    {
        public string Combustivel {  get; set; }
    }
}
