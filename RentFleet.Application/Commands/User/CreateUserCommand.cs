using MediatR;

namespace RentFleet.Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string NomeAtendente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
    }
}