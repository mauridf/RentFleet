using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetAllClientesByUFQueryHandler : IRequestHandler<GetAllClientesByUFQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesByUFQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> Handle(GetAllClientesByUFQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("UF", request.UF); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os clientes por UF.", request.UF);

                var clientes = await _clienteRepository.GetAllByUFAsync(request.UF);
                if (clientes == null)
                {
                    log.Warning("Nenhum Cliente foi encontrado nessa UF.", request);
                    throw new Exception("Nenhum cliente encontrado nessa UF.");
                }
                log.Information("Todos Clientes cadastrados nessa UF encontrados.", request);
                return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos clientes por UF.", request);
                throw;
            }
        }
    }
}
