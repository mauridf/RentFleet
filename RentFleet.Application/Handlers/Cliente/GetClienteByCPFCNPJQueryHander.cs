using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetClienteByCPFCNPJQueryHander : IRequestHandler<GetClienteByCPFCNPJQuery, ClienteDTO>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByCPFCNPJQueryHander(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(GetClienteByCPFCNPJQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("CPFCNPJ", request.CpfCnpj); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por CPF/CNPJ: {CPFCNPJ}.", request.CpfCnpj);

                var cliente = await _clienteRepository.GetByCPFCNPJAsync(request.CpfCnpj);
                if (cliente == null)
                {
                    log.Warning("Cliente com CPF/CNPJ {CPFCNPJ} não encontrado.", request.CpfCnpj);
                    throw new Exception("Cliente não encontrado.");
                }

                log.Information("Cliente {CPFCNPJ} encontrado com sucesso.", request.CpfCnpj);

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                log.Information("Mapeamento concluído com sucesso para o cliente {CPFCNPJ}.", request.CpfCnpj);

                return clienteDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por CPF/CNPJ: {CPFCNPJ}.", request.CpfCnpj);
                throw;
            }
        }
    }
}
