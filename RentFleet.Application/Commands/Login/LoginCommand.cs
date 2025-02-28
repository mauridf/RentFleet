using MediatR;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}