using MediatR;
using RentFleet.Application.Commands.FotoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.FotoVeiculo
{
    public class DeleteFotoVeiculoCommandHandler : IRequestHandler<DeleteFotoVeiculoCommand>
    {
        private readonly IFotoVeiculoRepository _fotoRepository;

        public DeleteFotoVeiculoCommandHandler(IFotoVeiculoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }

        public async Task<Unit> Handle(DeleteFotoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Foto", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo foto com ID: {Id}.", request.Id);

                var foto = await _fotoRepository.GetByIdAsync(request.Id);
                if (foto == null)
                {
                    log.Warning("Foto com ID {Id} não encontrada.", request.Id);
                    throw new Exception("Foto não encontrada.");
                }

                await _fotoRepository.DeleteAsync(request.Id);

                log.Information("Foto {Id} excluída com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir foto com ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
