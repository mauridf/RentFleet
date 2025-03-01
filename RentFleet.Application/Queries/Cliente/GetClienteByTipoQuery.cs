using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.Cliente
{
    public class GetClienteByTipoQuery : IRequest<IEnumerable<ClienteDTO>>
    {
        public string Tipo { get; set; } // "PF" para Pessoa Física ou "PJ" para Pessoa Jurídica
    }
}