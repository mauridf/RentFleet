using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetAllClientesByCidadeQueryHandler : IRequestHandler<GetAllClientesByCidadeQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesByCidadeQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> Handle(GetAllClientesByCidadeQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Cidade", request.Cidade); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os clientes por Cidade.", request.Cidade);

                var clientes = await _clienteRepository.GetAllByCidadeAsync(request.Cidade);
                if (clientes == null)
                {
                    log.Warning("Nenhum Cliente foi encontrado nessa Cidade.", request.Cidade);
                    throw new Exception("Nenhum cliente encontrado nessa Cidade.");
                }
                log.Information("Todos Clientes cadastrados nessa Cidade encontrados.", request.Cidade);
                return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos clientes por Cidade.", request.Cidade);
                throw;
            }
        }
    }
}
