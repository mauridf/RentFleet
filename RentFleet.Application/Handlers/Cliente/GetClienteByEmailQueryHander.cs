using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetClienteByEmailQueryHander : IRequestHandler<GetClienteByEmailQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByEmailQueryHander(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByEmailQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Email", request.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por E-mail: {Email}.", request.Email);

                var cliente = await _clienteRepository.GetByEmailAsync(request.Email);
                if (cliente == null)
                {
                    log.Warning("Cliente com E-mail {Email} não encontrado.", request.Email);
                    throw new Exception("Cliente não encontrado.");
                }

                log.Information("Cliente {E-mail} encontrado com sucesso.", request.Email);

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                log.Information("Mapeamento concluído com sucesso para o cliente {Email}.", request.Email);

                return clienteDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por E-mail: {Email}.", request.Email);
                throw;
            }
        }
    }
}
