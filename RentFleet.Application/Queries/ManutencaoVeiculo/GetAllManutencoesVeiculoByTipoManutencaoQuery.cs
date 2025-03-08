using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.Queries.ManutencaoVeiculo
{
    public class GetAllManutencoesVeiculoByTipoManutencaoQuery : IRequest<IEnumerable<ManutencaoVeiculoDTO>>
    {
        public string TipoManutencao { get; set; }
    }
}
