using MediatR;
using RentFleet.Application.Commands.Clientes;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Nome", request.Nome); // Adiciona contexto ao log

            try
            {
                log.Information("Editando cliente com nome: {Nome}.", request.Email);

                var cliente = await _clienteRepository.GetByIdAsync(request.Id);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado.");

                cliente.Nome = request.Nome;
                cliente.Telefone = request.Telefone;
                cliente.Email = request.Email;
                cliente.CpfCnpj = request.CpfCnpj;
                cliente.Tipo = request.Tipo;
                cliente.Endereco = request.Endereco;
                cliente.Cidade = request.Cidade;
                cliente.UF = request.UF;    
                cliente.DataAlteracao = DateTime.UtcNow;

                await _clienteRepository.UpdateAsync(cliente);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Cliente {Nome} editado com sucesso. ID: {ClienteId}.", request.Nome, cliente.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar o cliente com nome: {Nome}.", request.Nome);
                throw;
            }
        }
    }
}
