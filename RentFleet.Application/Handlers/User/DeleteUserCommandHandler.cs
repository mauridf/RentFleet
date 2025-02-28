using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RentFleet.Application.Handlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            await _userRepository.DeleteAsync(request.Id);

            // Retorna Unit.Value para indicar que o comando foi executado com sucesso
            return Unit.Value;
        }
    }
}