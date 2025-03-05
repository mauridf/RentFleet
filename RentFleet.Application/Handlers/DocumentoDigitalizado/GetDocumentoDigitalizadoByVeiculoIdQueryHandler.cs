using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DocumentoDigitalizado;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DocumentoDigitalizado
{
    public class GetDocumentoDigitalizadoByVeiculoIdQueryHandler : IRequestHandler<GetDocumentoDigitalizadoByVeiculoIdQuery, List<DocumentoDigitalizadoDTO>> // Alterado para lista
    {
        private readonly IDocumentoDigitalizadoRepository _documentoRepository;
        private readonly IMapper _mapper;

        public GetDocumentoDigitalizadoByVeiculoIdQueryHandler(IDocumentoDigitalizadoRepository documentoRepository, IMapper mapper)
        {
            _documentoRepository = documentoRepository;
            _mapper = mapper;
        }

        public async Task<List<DocumentoDigitalizadoDTO>> Handle(GetDocumentoDigitalizadoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.VeiculoId);

            try
            {
                log.Information("Buscando documentos digitalizados do veículo com VeiculoId: {VeiculoId}.", request.VeiculoId);

                var documentos = await _documentoRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (documentos == null || !documentos.Any())
                {
                    log.Warning("Nenhum documento digitalizado encontrado para o veículo {VeiculoId}.", request.VeiculoId);
                    return new List<DocumentoDigitalizadoDTO>();
                }

                log.Information("{Count} documentos digitalizados encontrados para o veículo {VeiculoId}.", documentos.Count, request.VeiculoId);

                var documentosDTO = _mapper.Map<List<DocumentoDigitalizadoDTO>>(documentos);
                return documentosDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar documentos digitalizados do veículo {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}