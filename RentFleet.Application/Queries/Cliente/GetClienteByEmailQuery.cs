using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetClienteByEmailQuery : IRequest<ClienteDTO>
    {
        public string Email { get; set; }
    }
}
