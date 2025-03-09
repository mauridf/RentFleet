using MediatR;
using RentFleet.Application.Commands.RegraDescontoJuros;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.RegraDescontoJuros
{
    public class DeleteRegraDescontoJurosCommandHandler : IRequestHandler<DeleteRegraDescontoJurosCommand>
    {
        private readonly IRegraDescontoJurosRepository _regraRepository;

        public DeleteRegraDescontoJurosCommandHandler(IRegraDescontoJurosRepository regraRepository)
        {
            _regraRepository = regraRepository;
        }

        public async Task<Unit> Handle(DeleteRegraDescontoJurosCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("RegraDescontoJuros", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo regra de desconto e juros ID: {Id}.", request.Id);

                var regra = await _regraRepository.GetByIdAsync(request.Id);
                if (regra == null)
                {
                    log.Warning("Regra de desconto e juros {Id} não encontrado.", request.Id);
                    throw new Exception("Regra de desconto e juros não encontrado.");
                }

                await _regraRepository.DeleteAsync(request.Id);

                log.Information("Regra de desconto e juros {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir regra de desconto e juros ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
