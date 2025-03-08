using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.ManutencaoVeiculo
{
    public class GetAllManutencoesVeiculoByVeiculoIdQuery : IRequest<IEnumerable<ManutencaoVeiculoDTO>>
    {
        public int VeiculoId { get; set; }
    }
}
