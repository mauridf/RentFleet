using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.FotoVeiculo
{
    public class GetFotoVeiculoByIdQuery : IRequest<FotoVeiculoDTO>
    {
        public int Id { get; set; }
    }
}
