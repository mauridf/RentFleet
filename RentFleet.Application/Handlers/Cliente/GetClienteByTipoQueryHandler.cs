using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Interfaces;
using AutoMapper;
using RentFleet.Application.Queries.Cliente;

namespace RentFleet.Application.Handlers.Cliente
{
    public class GetClienteByTipoQueryHandler : IRequestHandler<GetClienteByTipoQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteByTipoQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> Handle(GetClienteByTipoQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAllByTipoAsync(request.Tipo);
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }
    }
}