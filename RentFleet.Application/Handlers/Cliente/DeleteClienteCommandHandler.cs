using MediatR;
using RentFleet.Application.Commands.Clientes;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ClienteId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo cliente com ID: {ClienteId}.", request.Id);

                var cliente = await _clienteRepository.GetByIdAsync(request.Id);
                if (cliente == null)
                {
                    log.Warning("Cliente com ID {ClienteId} não encontrado.", request.Id);
                    throw new Exception("Cliente não encontrado.");
                }

                await _clienteRepository.DeleteAsync(request.Id);

                log.Information("Cliente {ClienteId} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir cliente com ID: {ClienteId}.", request.Id);
                throw;
            }
        }
    }
}
