using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetClienteByIdQueryHander : IRequestHandler<GetClienteByIdQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHander(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ClienteId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por ID: {ClienteId}.", request.Id);

                var cliente = await _clienteRepository.GetByIdAsync(request.Id);
                if (cliente == null)
                {
                    log.Warning("Cliente com ID {ClienteId} não encontrado.", request.Id);
                    throw new Exception("Cliente não encontrado.");
                }

                log.Information("Cliente {ClienteId} encontrado com sucesso.", request.Id);
                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Cliente por ID: {ClienteId}.", request.Id);
                throw;
            }
        }
    }
}
