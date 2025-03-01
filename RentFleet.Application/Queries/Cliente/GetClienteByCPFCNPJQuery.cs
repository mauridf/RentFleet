using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetClienteByCPFCNPJQuery : IRequest<ClienteDTO>
    {
        public string CpfCnpj { get; set; }
    }
}
