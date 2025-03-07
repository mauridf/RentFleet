using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosTecnicosVeiculo
{
    public class GetDadosTecnicosVeiculoByVeiculoIdQuery : IRequest<DadosTecnicosVeiculoDTO>
    {
        public int VeiculoId { get; set; }
    }
}
