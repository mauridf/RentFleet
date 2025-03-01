using MediatR;

namespace RentFleet.Application.Commands.Clientes
{
    public class UpdateClienteCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string Tipo { get; set; } // PF ou PJ
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
