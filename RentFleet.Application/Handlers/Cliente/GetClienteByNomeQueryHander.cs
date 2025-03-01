using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetClienteByNomeQueryHander : IRequestHandler<GetClienteByNomeQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByNomeQueryHander(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByNomeQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Nome", request.Nome); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por Nome: {Nome}.", request.Nome);

                var cliente = await _clienteRepository.GetByNomeAsync(request.Nome);
                if (cliente == null)
                {
                    log.Warning("Cliente com Nome {Nome} não encontrado.", request.Nome);
                    throw new Exception("Cliente não encontrado.");
                }

                log.Information("Cliente {Nome} encontrado com sucesso.", request.Nome);

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                log.Information("Mapeamento concluído com sucesso para o cliente {Nome}.", request.Nome);

                return clienteDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por Nome: {Nome}.", request.Nome);
                throw;
            }
        }
    }
}
