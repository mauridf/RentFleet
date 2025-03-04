using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosCaminhao;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosCaminhao
{
    public class GetDadosCaminhaoByIdQueryHandler : IRequestHandler<GetDadosCaminhaoByIdQuery, DadosCaminhaoDTO>
    {
        private readonly IDadosCaminhaoRepository _dadosCaminhaoRepository;
        private readonly IMapper _mapper;

        public GetDadosCaminhaoByIdQueryHandler(IDadosCaminhaoRepository dadosCaminhaoRepository, IMapper mapper)
        {
            _dadosCaminhaoRepository = dadosCaminhaoRepository;
            _mapper = mapper;
        }

        public async Task<DadosCaminhaoDTO> Handle(GetDadosCaminhaoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosCaminhaoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados do caminhão por ID: {DadosCaminhaoId}.", request.Id);

                var dadosCaminhao = await _dadosCaminhaoRepository.GetByIdAsync(request.Id);
                if (dadosCaminhao == null)
                {
                    log.Warning("Dados do caminhão com ID {DadosCaminhaoId} não encontrado.", request.Id);
                    throw new Exception("Dados do Caminhão não encontrado.");
                }

                log.Information("Dados do caminhão {DadosCaminhaoId} encontrado com sucesso.", request.Id);
                return _mapper.Map<DadosCaminhaoDTO>(dadosCaminhao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados do caminhão por ID: {DadosCaminhaoId}.", request.Id);
                throw;
            }
        }
    }
}
