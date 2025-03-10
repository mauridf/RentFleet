using MediatR;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class GetVeiculosDisponiveisQueryHandler : IRequestHandler<GetVeiculosDisponiveisQuery, List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
        private readonly ILocacaoVeiculoRepository _locacaoRepository;

        public GetVeiculosDisponiveisQueryHandler(ILocacaoVeiculoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<List<RentFleet.Domain.Entities.LocacaoVeiculo>> Handle(GetVeiculosDisponiveisQuery request, CancellationToken cancellationToken)
        {
            return await _locacaoRepository.GetVeiculosDisponiveis();
        }
    }
}
