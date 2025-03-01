using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetAllClientesQuery : IRequest<IEnumerable<ClienteDTO>>
    {
    }
}
