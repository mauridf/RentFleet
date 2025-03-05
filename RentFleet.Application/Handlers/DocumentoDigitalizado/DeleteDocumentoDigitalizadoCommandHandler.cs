using MediatR;
using RentFleet.Application.Commands.DocumentoDigitalizado;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DocumentoDigitalizado
{
    public class DeleteDocumentoDigitalizadoCommandHandler : IRequestHandler<DeleteDocumentoDigitalizadoCommand>
    {
        private readonly IDocumentoDigitalizadoRepository _documentoRepository;

        public DeleteDocumentoDigitalizadoCommandHandler(IDocumentoDigitalizadoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<Unit> Handle(DeleteDocumentoDigitalizadoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Documento", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo documento com ID: {Id}.", request.Id);

                var documento = await _documentoRepository.GetByIdAsync(request.Id);
                if (documento == null)
                {
                    log.Warning("Documento com ID {Id} não encontrado.", request.Id);
                    throw new Exception("Documento não encontrado.");
                }

                await _documentoRepository.DeleteAsync(request.Id);

                log.Information("Documento {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir documento com ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
