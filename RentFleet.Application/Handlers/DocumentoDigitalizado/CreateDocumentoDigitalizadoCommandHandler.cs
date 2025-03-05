using MediatR;
using RentFleet.Application.Commands.DocumentoDigitalizado;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DocumentoDigitalizado
{
    public class CreateDocumentoDigitalizadoCommandHandler : IRequestHandler<CreateDocumentoDigitalizadoCommand, int>
    {
        private readonly IDocumentoDigitalizadoRepository _documentoRepository;

        public CreateDocumentoDigitalizadoCommandHandler(IDocumentoDigitalizadoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<int> Handle(CreateDocumentoDigitalizadoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando documento digitalizado do veiculo: {VeiculoId}.", request.VeiculoId);

                var documento = new RentFleet.Domain.Entities.DocumentoDigitalizado
                {
                    VeiculoId = request.VeiculoId,
                    Descricao = request.Descricao,
                    UrlDocumento = request.UrlDocumento
                };

                await _documentoRepository.AddAsync(documento);

                log.Information("Documento do Veiculo {VeiculoId} adicionado com sucesso. ID: {Id}.", request.VeiculoId, documento.Id);
                return documento.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar documento do veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
