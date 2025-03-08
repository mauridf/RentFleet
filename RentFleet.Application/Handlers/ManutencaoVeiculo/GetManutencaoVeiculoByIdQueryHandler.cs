using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class GetManutencaoVeiculoByIdQueryHandler : IRequestHandler<GetManutencaoVeiculoByIdQuery, ManutencaoVeiculoDTO>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetManutencaoVeiculoByIdQueryHandler(IManutencaoVeiculoRepository manutencaoVeiculoRepository, IMapper mapper)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<ManutencaoVeiculoDTO> Handle(GetManutencaoVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ManutencaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando a informação de manutenção: {Id}.", request.Id);

                var manutencao = await _manutencaoVeiculoRepository.GetByIdAsync(request.Id);
                if (manutencao == null)
                {
                    log.Warning("Informação de manutenção {Id} não encontrada.", request.Id);
                    throw new Exception("Informação de Manutenção não encontrada.");
                }

                log.Information("Informação de Manutenção {Id} encontrada com sucesso.", request.Id);

                var manutencaoDTO = _mapper.Map<ManutencaoVeiculoDTO>(manutencao);
                log.Information("Mapeamento concluído com sucesso para a informação de manutenção {Id}.", request.Id);

                return manutencaoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar informação de manutenção: {Id}.", request.Id);
                throw;
            }
        }
    }
}
