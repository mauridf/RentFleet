using MediatR;
using RentFleet.Application.Commands.DadosTecnicosVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosTecnicosVeiculo
{
    public class DeleteDadosTecnicosVeiculoCommandHandler : IRequestHandler<DeleteDadosTecnicosVeiculoCommand>
    {
        private readonly IDadosTecnicosVeiculoRepository _tecnicoRepository;

        public DeleteDadosTecnicosVeiculoCommandHandler(IDadosTecnicosVeiculoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
        }

        public async Task<Unit> Handle(DeleteDadosTecnicosVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosTecnicosId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados tecnicos ID: {Id}.", request.Id);

                var tecnico = await _tecnicoRepository.GetByIdAsync(request.Id);
                if (tecnico == null)
                {
                    log.Warning("dados tenicos ID {Id} não encontrado.", request.Id);
                    throw new Exception("dados tecnicos não encontrado.");
                }

                await _tecnicoRepository.DeleteAsync(request.Id);

                log.Information("dados tecnicos {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados tecnicos ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
