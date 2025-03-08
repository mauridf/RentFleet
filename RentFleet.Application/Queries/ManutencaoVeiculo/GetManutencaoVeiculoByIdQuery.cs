using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.ManutencaoVeiculo
{
    public class GetManutencaoVeiculoByIdQuery : IRequest<ManutencaoVeiculoDTO>
    {
        public int Id { get; set; }
    }
}
