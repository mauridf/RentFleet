using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetAllClientesByUFQuery : IRequest<IEnumerable<ClienteDTO>>
    {
        public string UF { get; set; }
    }
}
