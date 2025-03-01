using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Clientes", request); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os clientes.", request);

                var clientes = await _clienteRepository.GetAllAsync();
                if (clientes == null)
                {
                    log.Warning("Nenhum Cliente foi encontrado.", request);
                    throw new Exception("Nenhum cliente encontrado.");
                }
                log.Information("Todos Clientes cadastrados encontrados.", request);
                return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos clientes.", request);
                throw;
            }
        }
    }
}
