using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.LocacaoVeiculo
{
    public class GetAllLocacoesVeiculoByClienteIdQuery : IRequest<IEnumerable<LocacaoVeiculoDTO>>
    {
        public int ClienteId { get; set; }
    }
}
