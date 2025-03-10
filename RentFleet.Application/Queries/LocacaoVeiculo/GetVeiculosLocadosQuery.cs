using MediatR;

namespace RentFleet.Application.Queries.LocacaoVeiculo
{
    public class GetVeiculosLocadosQuery : IRequest<List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
    }
}
