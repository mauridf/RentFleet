using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class GetAllLocacaoVeiculoByVeiculoIdQueryHandler : IRequestHandler<GetAllLocacoesVeiculoByVeiculoIdQuery, IEnumerable<LocacaoVeiculoDTO>>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetAllLocacaoVeiculoByVeiculoIdQueryHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository, IMapper mapper)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocacaoVeiculoDTO>> Handle(GetAllLocacoesVeiculoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as locações por Veículo.", request.VeiculoId);

                var locacoes = await _locacaoVeiculoRepository.GetAllByVeiculoIdAsync(request.VeiculoId);
                if (locacoes == null)
                {
                    log.Warning("Nenhuma locação do Veiculo {VeiculoId} foi encontrada.", request.VeiculoId);
                    throw new Exception("Nenhuma locação do Cliente foi encontrada.");
                }
                log.Information("Todos as locações do Veiculo {VeiculoId} foram encontradas.", request.VeiculoId);
                return _mapper.Map<IEnumerable<LocacaoVeiculoDTO>>(locacoes);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as locações do veiculo {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
