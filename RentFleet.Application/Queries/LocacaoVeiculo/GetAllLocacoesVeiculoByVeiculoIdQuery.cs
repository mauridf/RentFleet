using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.LocacaoVeiculo
{
    public class GetAllLocacoesVeiculoByVeiculoIdQuery : IRequest<IEnumerable<LocacaoVeiculoDTO>>
    {
        public int VeiculoId { get; set; }
    }
}
