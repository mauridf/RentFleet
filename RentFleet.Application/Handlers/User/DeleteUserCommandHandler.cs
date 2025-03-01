using MediatR;
using RentFleet.Application.Commands;
using RentFleet.Domain.Interfaces;
using Serilog;
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
            var log = Log.ForContext("UserId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo usuário com ID: {UserId}.", request.Id);

                var user = await _userRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    log.Warning("Usuário com ID {UserId} não encontrado.", request.Id);
                    throw new Exception("Usuário não encontrado.");
                }

                await _userRepository.DeleteAsync(request.Id);

                log.Information("Usuário {UserId} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir usuário com ID: {UserId}.", request.Id);
                throw;
            }
        }
    }
}