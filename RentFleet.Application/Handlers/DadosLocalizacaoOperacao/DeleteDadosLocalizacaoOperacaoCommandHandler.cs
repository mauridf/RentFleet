using MediatR;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosLocalizacaoOperacao
{
    public class DeleteDadosLocalizacaoOperacaoCommandHandler : IRequestHandler<DeleteDadosLocalizacaoOperacaoCommand>
    {
        private readonly IDadosLocalizacaoOperacaoRepository _dadosLocOperRepository;

        public DeleteDadosLocalizacaoOperacaoCommandHandler(IDadosLocalizacaoOperacaoRepository dadosLocOperRepository)
        {
            _dadosLocOperRepository = dadosLocOperRepository;
        }

        public async Task<Unit> Handle(DeleteDadosLocalizacaoOperacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosLocalizacaoOperacao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados de localização e operação com ID: {Id}.", request.Id);

                var dadosLocOper = await _dadosLocOperRepository.GetByIdAsync(request.Id);
                if (dadosLocOper == null)
                {
                    log.Warning("Dados de localização e operação com ID {Id} não encontrado.", request.Id);
                    throw new Exception("Dados de localização e operação não encontrado.");
                }

                await _dadosLocOperRepository.DeleteAsync(request.Id);

                log.Information("Dados de localização e operação {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados de localização e operação com ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
