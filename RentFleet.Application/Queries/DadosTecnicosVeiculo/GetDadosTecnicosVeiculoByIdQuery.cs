using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DadosTecnicosVeiculo
{
    public class GetDadosTecnicosVeiculoByIdQuery : IRequest<DadosTecnicosVeiculoDTO>
    {
        public int Id { get; set; }
    }
}
