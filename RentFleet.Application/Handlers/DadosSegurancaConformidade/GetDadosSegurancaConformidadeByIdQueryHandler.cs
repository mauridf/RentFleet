using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosSegurancaConformidade;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosSegurancaConformidade
{
    public class GetDadosSegurancaConformidadeByIdQueryHandler : IRequestHandler<GetDadosSegurancaConformidadeByIdQuery, DadosSegurancaConformidadeDTO>
    {
        private IDadosSegurancaConformidadeRepository _segurancaConformidadeRepository;
        private IMapper _mapper;

        public GetDadosSegurancaConformidadeByIdQueryHandler(IDadosSegurancaConformidadeRepository segurancaConformidadeRepository, IMapper mapper)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
            _mapper = mapper;
        }

        public async Task<DadosSegurancaConformidadeDTO> Handle(GetDadosSegurancaConformidadeByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("SegurancaConformidade", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados de segurança e conformidade por ID: {Id}.", request.Id);

                var segurancaConformidade = await _segurancaConformidadeRepository.GetByIdAsync(request.Id);
                if (segurancaConformidade == null)
                {
                    log.Warning("Dados de segurança e conformidade com ID {Id} não encontrado.", request.Id);
                    throw new Exception("Dados de segurança e conformidade não encontrado.");
                }

                log.Information("Dados de segurança e conformidade {Id} encontrado com sucesso.", request.Id);
                return _mapper.Map<DadosSegurancaConformidadeDTO>(segurancaConformidade);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados de Segurança e Conformidade por ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
