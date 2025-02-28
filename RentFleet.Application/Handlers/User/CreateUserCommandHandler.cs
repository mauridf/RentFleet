using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Security;
using System.Threading;
using System.Threading.Tasks;

namespace RentFleet.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RentFleet.Domain.Entities.User
            {
                NomeAtendente = request.NomeAtendente,
                Telefone = request.Telefone,
                Email = request.Email,
                Senha = _passwordHasher.HashPassword(request.Senha),
                Tipo = request.Tipo,
                Ativo = true,
                DataCadastro = DateTime.UtcNow,
                DataAlteracao = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}