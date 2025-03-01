using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetClienteByIdQuery : IRequest<ClienteDTO>
    {
        public int Id { get; set; }
    }
}
