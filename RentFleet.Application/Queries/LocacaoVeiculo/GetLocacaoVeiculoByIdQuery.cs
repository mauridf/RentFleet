using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.LocacaoVeiculo
{
    public class GetLocacaoVeiculoByIdQuery : IRequest<LocacaoVeiculoDTO>
    {
        public int Id { get; set; }
    }
}
