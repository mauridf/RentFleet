using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Dashboard;
using RentFleet.Application.Services;

namespace RentFleet.Application.Handlers.Dashboard
{
    public class GetLocacoesPorMesQueryHandler : IRequestHandler<GetLocacoesPorMesQuery, List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
        private readonly DashboardService _dashboardService;

        public GetLocacoesPorMesQueryHandler(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<List<RentFleet.Domain.Entities.LocacaoVeiculo>> Handle(GetLocacoesPorMesQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetLocacoesPorMes(request.Ano, request.Mes);
        }
    }
}
