using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Security;
using Serilog;
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
            var log = Log.ForContext("Email", request.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Criando novo usuário com email: {Email}.", request.Email);

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

                log.Information("Usuário {Email} criado com sucesso. ID: {UserId}.", request.Email, user.Id);
                return user.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar usuário com email: {Email}.", request.Email);
                throw;
            }
        }
    }
}