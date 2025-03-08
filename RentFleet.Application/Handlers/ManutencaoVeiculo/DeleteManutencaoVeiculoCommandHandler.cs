using MediatR;
using RentFleet.Application.Commands.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class DeleteManutencaoVeiculoCommandHandler : IRequestHandler<DeleteManutencaoVeiculoCommand>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;

        public DeleteManutencaoVeiculoCommandHandler(IManutencaoVeiculoRepository manutencaoVeiculoRepository)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
        }

        public async Task<Unit> Handle(DeleteManutencaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ManutencaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo informação de manutenção do veículo ID: {Id}.", request.Id);

                var manutencao = await _manutencaoVeiculoRepository.GetByIdAsync(request.Id);
                if (manutencao == null)
                {
                    log.Warning("Informação de Manutenção de veículo {Id} não encontrado.", request.Id);
                    throw new Exception("Informação de Manutenção de veículo não encontrado.");
                }

                await _manutencaoVeiculoRepository.DeleteAsync(request.Id);

                log.Information("Informação de Manutenção de veículo {Id} excluído com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir informação de Manutenção de veículo ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
