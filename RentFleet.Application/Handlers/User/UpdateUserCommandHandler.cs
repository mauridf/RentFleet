using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Security;
using Serilog;

namespace RentFleet.Application.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Email", request.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Editando usuário com email: {Email}.", request.Email);

                var user = await _userRepository.GetByIdAsync(request.Id);
                if (user == null)
                    throw new Exception("Usuário não encontrado.");

                user.NomeAtendente = request.NomeAtendente;
                user.Telefone = request.Telefone;
                user.Email = request.Email;
                user.Senha = _passwordHasher.HashPassword(request.Senha);
                user.Tipo = request.Tipo;
                user.Ativo = request.Ativo;
                user.DataAlteracao = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Usuário {Email} editado com sucesso. ID: {UserId}.", request.Email, user.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar usuário com email: {Email}.", request.Email);
                throw;
            }
        }
    }
}