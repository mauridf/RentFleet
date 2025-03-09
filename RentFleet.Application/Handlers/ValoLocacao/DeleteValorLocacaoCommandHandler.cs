using MediatR;
using RentFleet.Application.Commands.ValorLocacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ValoLocacao
{
    public class DeleteValorLocacaoCommandHandler : IRequestHandler<DeleteValorLocacaoCommand>
    {
        private readonly IValorLocacaoRepository _valorLocacaoRepository;

        public DeleteValorLocacaoCommandHandler(IValorLocacaoRepository valorLocacaoRepository)
        {
            _valorLocacaoRepository = valorLocacaoRepository;
        }

        public async Task<Unit> Handle(DeleteValorLocacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ValorLocacao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo Valor de Locação ID: {Id}.", request.Id);

                var valor = await _valorLocacaoRepository.GetByIdAsync(request.Id);
                if (valor == null)
                {
                    log.Warning("Valor de Locação {Id} não encontrado.", request.Id);
                    throw new Exception("Valor de Locação não encontrado.");
                }

                await _valorLocacaoRepository.DeleteAsync(request.Id);

                log.Information("Valor de Locação {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir valor de locação ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
