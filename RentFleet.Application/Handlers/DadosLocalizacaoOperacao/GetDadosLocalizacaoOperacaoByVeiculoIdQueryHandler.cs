using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosLocalizacaoOperacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosLocalizacaoOperacao
{
    public class GetDadosLocalizacaoOperacaoByVeiculoIdQueryHandler : IRequestHandler<GetDadosLocalizacaoOperacaoByVeiculoIdQuery, DadosLocalizacaoOperacaoDTO>
    {
        private readonly IDadosLocalizacaoOperacaoRepository _dadosLocOperRepository;
        private readonly IMapper _mapper;

        public GetDadosLocalizacaoOperacaoByVeiculoIdQueryHandler(IDadosLocalizacaoOperacaoRepository dadosLocOper, IMapper mapper)
        {
            _dadosLocOperRepository = dadosLocOper;
            _mapper = mapper;
        }

        public async Task<DadosLocalizacaoOperacaoDTO> Handle(GetDadosLocalizacaoOperacaoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosLocalizacaoOperacao", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados de Localização e Operação por ID: {Id}.", request.VeiculoId);

                var dadosLocOper = await _dadosLocOperRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (dadosLocOper == null)
                {
                    log.Warning("Dados de Localização e Operação com ID {Id} não encontrado.", request.VeiculoId);
                    throw new Exception("Dados de Localização e Operação não encontrado.");
                }

                log.Information("Dados de Localização e Operação {Id} encontrado com sucesso.", request.VeiculoId);
                return _mapper.Map<DadosLocalizacaoOperacaoDTO>(dadosLocOper);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados de Localização e Operação por ID: {Id}.", request.VeiculoId);
                throw;
            }
        }
    }
}
