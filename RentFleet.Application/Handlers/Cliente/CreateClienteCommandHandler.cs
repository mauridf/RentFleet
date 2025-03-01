using MediatR;
using RentFleet.Application.Commands.Clientes;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Nome", request.Nome); // Adiciona contexto ao log

            try
            {
                log.Information("Criando novo cliente com nome: {Nome}.", request.Nome);

                var cliente = new RentFleet.Domain.Entities.Cliente
                {
                    Nome = request.Nome,
                    Telefone = request.Telefone,
                    Email = request.Email,
                    CpfCnpj = request.CpfCnpj,
                    Tipo = request.Tipo,
                    Endereco = request.Endereco,
                    Cidade = request.Cidade,
                    UF = request.UF,
                    DataCadastro = DateTime.UtcNow,
                    DataAlteracao = DateTime.UtcNow
                };

                await _clienteRepository.AddAsync(cliente);

                log.Information("Cliente {Nome} criado com sucesso. ID: {ClienteId}.", request.Nome, cliente.Id);
                return cliente.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar o cliente com nome: {Nome}.", request.Nome);
                throw;
            }
        }
    }
}
