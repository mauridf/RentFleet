using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosTecnicosVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosTecnicosVeiculo
{
    public class GetDadosTecnicosVeiculoByVeiculoIdQueryHandler : IRequestHandler<GetDadosTecnicosVeiculoByVeiculoIdQuery, DadosTecnicosVeiculoDTO>
    {
        private readonly IDadosTecnicosVeiculoRepository _tecnicoRepository;
        private readonly IMapper _mapper;

        public GetDadosTecnicosVeiculoByVeiculoIdQueryHandler(IDadosTecnicosVeiculoRepository tecnicoRepository, IMapper mapper)
        {
            _tecnicoRepository = tecnicoRepository;
            _mapper = mapper;
        }

        public async Task<DadosTecnicosVeiculoDTO> Handle(GetDadosTecnicosVeiculoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados tecnicos do veículo ID: {VeiculoId}.", request.VeiculoId);

                var tecnico = await _tecnicoRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (tecnico == null)
                {
                    log.Warning("Dados tecnicos do veículo ID {VeiculoId} não encontrado.", request.VeiculoId);
                    throw new Exception("Dados tecnicos do veículo não encontrado.");
                }

                log.Information("Dados tecnicos do veiculo {VeiculoId} encontrado com sucesso.", request.VeiculoId);
                return _mapper.Map<DadosTecnicosVeiculoDTO>(tecnico);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados tecnicos do Veiculo ID: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
