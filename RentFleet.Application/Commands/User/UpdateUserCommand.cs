using MediatR;

namespace RentFleet.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string NomeAtendente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}