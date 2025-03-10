using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Dashboard
{
    public class GetDashboardDataQuery : IRequest<DashboardDTO>
    {
        public int Ano { get; set; }
        public int Mes { get; set; }

        public GetDashboardDataQuery(int ano, int mes)
        {
            Ano = ano;
            Mes = mes;
        }
    }
}
