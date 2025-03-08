using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class GetAllManutencoesVeiculoByVeiculoIdQueryHandler : IRequestHandler<GetAllManutencoesVeiculoByVeiculoIdQuery, IEnumerable<ManutencaoVeiculoDTO>>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetAllManutencoesVeiculoByVeiculoIdQueryHandler(IManutencaoVeiculoRepository manutencaoVeiculoRepository, IMapper mapper)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManutencaoVeiculoDTO>> Handle(GetAllManutencoesVeiculoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as informações de manutenção do veículo.", request.VeiculoId);

                var manutencao = await _manutencaoVeiculoRepository.GetAllByVeiculoIdAsync(request.VeiculoId);
                if (manutencao == null)
                {
                    log.Warning("Nenhuma informação de manutenção desse veículo {VeiculoId} foi encontrada.", request.VeiculoId);
                    throw new Exception("Nenhum informação de manutenção desse veículo foi encontrada.");
                }
                log.Information("Todas as informações de manutenção do veículo {VeiculoId} foram encontradas.", request.VeiculoId);
                return _mapper.Map<IEnumerable<ManutencaoVeiculoDTO>>(manutencao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as informações de manutenção do veículo {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
