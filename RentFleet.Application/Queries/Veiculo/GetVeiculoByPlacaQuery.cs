using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Veiculo
{
    public class GetVeiculoByPlacaQuery : IRequest<VeiculoDTO>
    {
        public string Placa { get; set; }
    }
}
