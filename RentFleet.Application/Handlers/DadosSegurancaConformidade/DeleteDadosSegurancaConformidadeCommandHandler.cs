using MediatR;
using RentFleet.Application.Commands.DadosSegurancaConformidade;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosSegurancaConformidade
{
    public class DeleteDadosSegurancaConformidadeCommandHandler : IRequestHandler<DeleteDadosSegurancaConformidadeCommand>
    {
        private readonly IDadosSegurancaConformidadeRepository _segurancaConformidadeRepository;

        public DeleteDadosSegurancaConformidadeCommandHandler(IDadosSegurancaConformidadeRepository segurancaConformidadeRepository)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
        }

        public async Task<Unit> Handle(DeleteDadosSegurancaConformidadeCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("SegurancaConformidade", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados de segurança e conformidade com ID: {Id}.", request.Id);

                var segurancaConformidade = await _segurancaConformidadeRepository.GetByIdAsync(request.Id);
                if (segurancaConformidade == null)
                {
                    log.Warning("Dados de segurança e conformidade com ID {Id} não encontrado.", request.Id);
                    throw new Exception("Dados de segurança e conformidade não encontrado.");
                }

                await _segurancaConformidadeRepository.DeleteAsync(request.Id);

                log.Information("Dados de segurança e conformidade {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados de segurança e conformidade com ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
