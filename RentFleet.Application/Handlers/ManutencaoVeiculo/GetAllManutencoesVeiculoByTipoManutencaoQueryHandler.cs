using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class GetAllManutencoesVeiculoByTipoManutencaoQueryHandler : IRequestHandler<GetAllManutencoesVeiculoByTipoManutencaoQuery,IEnumerable<ManutencaoVeiculoDTO>>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetAllManutencoesVeiculoByTipoManutencaoQueryHandler (IManutencaoVeiculoRepository manutencaoVeiculoRepository, IMapper mapper)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManutencaoVeiculoDTO>> Handle(GetAllManutencoesVeiculoByTipoManutencaoQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Tipo", request.TipoManutencao); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as informações de manutenção por Tipo de Manutenção.", request.TipoManutencao);

                var manutencao = await _manutencaoVeiculoRepository.GetAllByTipoManutencaoAsync(request.TipoManutencao);
                if (manutencao == null)
                {
                    log.Warning("Nenhuma informação de manutenção por tipo {TipoManutencao} foi encontrada.", request.TipoManutencao);
                    throw new Exception("Nenhuma informação de manutenção por tipo foi encontrada.");
                }
                log.Information("Todas as informações de manutenção por tipo {TipoManutencao} foram encontradas.", request.TipoManutencao);
                return _mapper.Map<IEnumerable<ManutencaoVeiculoDTO>>(manutencao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as informações de manutenção por tipo {TipoManutencao}.", request.TipoManutencao);
                throw;
            }
        }
    }
}
