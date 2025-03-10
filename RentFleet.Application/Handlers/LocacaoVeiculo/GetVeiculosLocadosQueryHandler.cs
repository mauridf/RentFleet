using MediatR;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class GetVeiculosLocadosQueryHandler : IRequestHandler<GetVeiculosLocadosQuery, List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
        private readonly ILocacaoVeiculoRepository _locacaoRepository;

        public GetVeiculosLocadosQueryHandler(ILocacaoVeiculoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<List<RentFleet.Domain.Entities.LocacaoVeiculo>> Handle(GetVeiculosLocadosQuery request, CancellationToken cancellationToken)
        {
            return await _locacaoRepository.GetVeiculosLocados();
        }
    }
}
