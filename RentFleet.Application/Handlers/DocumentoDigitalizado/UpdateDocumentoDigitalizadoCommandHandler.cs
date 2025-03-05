using MediatR;
using RentFleet.Application.Commands.DocumentoDigitalizado;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DocumentoDigitalizado
{
    public class UpdateDocumentoDigitalizadoCommandHandler : IRequestHandler<UpdateDocumentoDigitalizadoCommand>
    {
        private readonly IDocumentoDigitalizadoRepository _documentoRepository;

        public UpdateDocumentoDigitalizadoCommandHandler(IDocumentoDigitalizadoRepository documento)
        {
            _documentoRepository = documento;
        }

        public async Task<Unit> Handle(UpdateDocumentoDigitalizadoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Documento", request.Id); // Adiciona contexto ao log
            try
            {
                log.Information("Editando documento: {Documento}.", request.Id);

                var documento = await _documentoRepository.GetByIdAsync(request.Id);
                if (documento == null)
                    throw new Exception("Documento não encontrado.");

                documento.VeiculoId = request.Id;
                documento.Descricao = request.Descricao;
                documento.UrlDocumento = request.UrlDocumento;

                await _documentoRepository.UpdateAsync(documento);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Documento do veículo {VeiculoId} editado com sucesso. ID: {Id}.", request.VeiculoId, documento.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar o documento: {Documento}.", request.Id);
                throw;
            }
        }
    }
}
