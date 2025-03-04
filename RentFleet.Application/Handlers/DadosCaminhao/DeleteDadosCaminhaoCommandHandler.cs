using MediatR;
using RentFleet.Application.Commands.DadosCaminhao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosCaminhao
{
    public class DeleteDadosCaminhaoCommandHandler : IRequestHandler<DeleteDadosCaminhaoCommand>
    {
        private readonly IDadosCaminhaoRepository _dadosCaminhaoRepository;

        public DeleteDadosCaminhaoCommandHandler(IDadosCaminhaoRepository dadosCaminhaoRepository)
        {
            _dadosCaminhaoRepository = dadosCaminhaoRepository;
        }

        public async Task<Unit> Handle(DeleteDadosCaminhaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosCaminhaoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados do caminhão com ID: {DadosCaminhaoId}.", request.Id);

                var dadosCaminhao = await _dadosCaminhaoRepository.GetByIdAsync(request.Id);
                if (dadosCaminhao == null)
                {
                    log.Warning("Dados do Caminhão com ID {DadosCaminhaoId} não encontrado.", request.Id);
                    throw new Exception("Dados do Caminhão não encontrado.");
                }

                await _dadosCaminhaoRepository.DeleteAsync(request.Id);

                log.Information("Dados do Caminhão {DadosCaminhaoId} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados do caminhão com ID: {DadosCaminhaoId}.", request.Id);
                throw;
            }
        }
    }
}
