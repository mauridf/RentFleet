using MediatR;

namespace RentFleet.Application.Queries.LocacaoVeiculo
{
    public class GetVeiculosDisponiveisQuery : IRequest<List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
    }
}
