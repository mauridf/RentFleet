using MediatR;
using RentFleet.Application.Commands.DadosMoto;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosMoto
{
    public class DeleteDadosMotoCommandHandler : IRequestHandler<DeleteDadosMotoCommand>
    {
        private readonly IDadosMotoRepository _dadosMotoRepository;

        public DeleteDadosMotoCommandHandler(IDadosMotoRepository dadosMotoRepository)
        {
            _dadosMotoRepository = dadosMotoRepository;
        }

        public async Task<Unit> Handle(DeleteDadosMotoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosMotoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados da moto com ID: {DadosMotoId}.", request.Id);

                var dadosMoto = await _dadosMotoRepository.GetByIdAsync(request.Id);
                if (dadosMoto == null)
                {
                    log.Warning("dados da moto com ID {DadosMotoId} não encontrado.", request.Id);
                    throw new Exception("dados da moto não encontrado.");
                }

                await _dadosMotoRepository.DeleteAsync(request.Id);

                log.Information("dados da moto {DadosMotoId} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados da moto com ID: {DadosMotoId}.", request.Id);
                throw;
            }
        }
    }
}
