using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetAllClientesByCidadeQuery : IRequest<IEnumerable<ClienteDTO>>
    {
        public string Cidade { get; set; }
    }
}
