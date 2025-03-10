using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Dashboard;
using RentFleet.Application.Services;

namespace RentFleet.Application.Handlers.Dashboard
{
    public class GetDashboardDataQueryHandler : IRequestHandler<GetDashboardDataQuery, DashboardDTO>
    {
        private readonly DashboardService _dashboardService;

        public GetDashboardDataQueryHandler(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<DashboardDTO> Handle(GetDashboardDataQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetDashboardData(request.Ano, request.Mes);
        }
    }
}
