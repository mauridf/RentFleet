using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Dashboard
{
    public class GetLocacoesPorMesQuery : IRequest<List<RentFleet.Domain.Entities.LocacaoVeiculo>>
    {
        public int Ano { get; set; }
        public int Mes { get; set; }

        public GetLocacoesPorMesQuery(int ano, int mes)
        {
            Ano = ano;
            Mes = mes;
        }
    }
}
