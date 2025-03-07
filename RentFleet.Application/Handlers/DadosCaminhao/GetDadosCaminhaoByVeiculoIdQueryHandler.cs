using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosCaminhao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosCaminhao
{
    public class GetDadosCaminhaoByVeiculoIdQueryHandler : IRequestHandler<GetDadosCaminhaoByVeiculoIdQuery, DadosCaminhaoDTO>
    {
        private readonly IDadosCaminhaoRepository _dadosCaminhaoRepository;
        private readonly IMapper _mapper;

        public GetDadosCaminhaoByVeiculoIdQueryHandler(IDadosCaminhaoRepository dadosCaminhaoRepository, IMapper mapper)
        {
            _dadosCaminhaoRepository = dadosCaminhaoRepository;
            _mapper = mapper;
        }

        public async Task<DadosCaminhaoDTO> Handle(GetDadosCaminhaoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosCaminhaoId", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados do caminhão por ID: {DadosCaminhaoId}.", request.VeiculoId);

                var dadosCaminhao = await _dadosCaminhaoRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (dadosCaminhao == null)
                {
                    log.Warning("Dados do caminhão com ID {DadosCaminhaoId} não encontrado.", request.VeiculoId);
                    throw new Exception("Dados do Caminhão não encontrado.");
                }

                log.Information("Dados do caminhão {DadosCaminhaoId} encontrado com sucesso.", request.VeiculoId);
                return _mapper.Map<DadosCaminhaoDTO>(dadosCaminhao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados do caminhão por ID: {DadosCaminhaoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
