using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosSegurancaConformidade;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosSegurancaConformidade
{
    public class GetDadosSegurancaConformidadeByVeiculoIdQueryHandler : IRequestHandler<GetDadosSegurancaConformidadeByVeiculoIdQuery, DadosSegurancaConformidadeDTO>
    {
        private IDadosSegurancaConformidadeRepository _segurancaConformidadeRepository;
        private IMapper _mapper;

        public GetDadosSegurancaConformidadeByVeiculoIdQueryHandler(IDadosSegurancaConformidadeRepository segurancaConformidadeRepository, IMapper mapper)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
            _mapper = mapper;
        }

        public async Task<DadosSegurancaConformidadeDTO> Handle(GetDadosSegurancaConformidadeByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("SegurancaConformidade", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados de segurança e conformidade por ID: {Id}.", request.VeiculoId);

                var segurancaConformidade = await _segurancaConformidadeRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (segurancaConformidade == null)
                {
                    log.Warning("Dados de segurança e conformidade com ID {Id} não encontrado.", request.VeiculoId);
                    throw new Exception("Dados de segurança e conformidade não encontrado.");
                }

                log.Information("Dados de segurança e conformidade {Id} encontrado com sucesso.", request.VeiculoId);
                return _mapper.Map<DadosSegurancaConformidadeDTO>(segurancaConformidade);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados de Segurança e Conformidade por ID: {Id}.", request.VeiculoId);
                throw;
            }
        }
    }
}
