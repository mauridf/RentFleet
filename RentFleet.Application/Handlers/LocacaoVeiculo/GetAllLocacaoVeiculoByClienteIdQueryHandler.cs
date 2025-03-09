using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class GetAllLocacaoVeiculoByClienteIdQueryHandler : IRequestHandler<GetAllLocacoesVeiculoByClienteIdQuery, IEnumerable<LocacaoVeiculoDTO>>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetAllLocacaoVeiculoByClienteIdQueryHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository, IMapper mapper)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocacaoVeiculoDTO>> Handle(GetAllLocacoesVeiculoByClienteIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.ClienteId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as locações por Cliente.", request.ClienteId);

                var locacoes = await _locacaoVeiculoRepository.GetAllByClienteIdAsync(request.ClienteId);
                if (locacoes == null)
                {
                    log.Warning("Nenhuma locação do Cliente {ClienteId} foi encontrada.", request.ClienteId);
                    throw new Exception("Nenhuma locação do Cliente foi encontrada.");
                }
                log.Information("Todos as locações do Cliente {ClienteId} foram encontradas.", request.ClienteId);
                return _mapper.Map<IEnumerable<LocacaoVeiculoDTO>>(locacoes);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as locações do cliente {ClienteId}.", request.ClienteId);
                throw;
            }
        }
    }
}
