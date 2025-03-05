using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DocumentoDigitalizado;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DocumentoDigitalizado
{
    public class GetDocumentoDigitalizadoByIdQueryHandler : IRequestHandler<GetDocumentoDigitalizadoByIdQuery, DocumentoDigitalizadoDTO>
    {
        private readonly IDocumentoDigitalizadoRepository _documentoRepository;
        private readonly IMapper _mapper;

        public GetDocumentoDigitalizadoByIdQueryHandler(IDocumentoDigitalizadoRepository documentoDigitalizadoRepository, IMapper mapper)
        {
            _documentoRepository = documentoDigitalizadoRepository;
            _mapper = mapper;
        }

        public async Task<DocumentoDigitalizadoDTO> Handle(GetDocumentoDigitalizadoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Id", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando o documento digitalizado do pelo Id: {Id}.", request.Id);

                var documento = await _documentoRepository.GetByIdAsync(request.Id);
                if (documento == null)
                {
                    log.Warning("Documento digitalizado Id {Id} não encontrado.", request.Id);
                    throw new Exception("Documento digitalizado não encontrado.");
                }

                log.Information("Documento digitalizado {Id} encontrado com sucesso.", request.Id);

                var documentoDTO = _mapper.Map<DocumentoDigitalizadoDTO>(documento);
                log.Information("Mapeamento concluído com sucesso para o documento digitalizado {Id}.", request.Id);

                return documentoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar documento digitalizado : {Id}.", request.Id);
                throw;
            }
        }
    }
}
