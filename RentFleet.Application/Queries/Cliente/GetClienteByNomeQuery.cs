using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetClienteByNomeQuery : IRequest<ClienteDTO>
    {
        public string Nome { get; set; }
    }
}
