using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Security;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            return Unit.Value;
        }
    }
}