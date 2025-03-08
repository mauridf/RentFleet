using MediatR;
using RentFleet.Application.Commands.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class CreateManutencaoVeiculoCommandHandler : IRequestHandler<CreateManutencaoVeiculoCommand, int>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;

        public CreateManutencaoVeiculoCommandHandler(IManutencaoVeiculoRepository manutencaoVeiculoRepository)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
        }

        public async Task<int> Handle(CreateManutencaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando informação de manutenção do veículo: {VeiculoId}.", request.VeiculoId);

                var manutencao = new RentFleet.Domain.Entities.ManutencaoVeiculo
                {
                    VeiculoId = request.VeiculoId,
                    DataManutencao = request.DataManutencao,
                    TipoManutencao = request.TipoManutencao,
                    Descricao = request.Descricao,
                    Custo = request.Custo,
                    Quilometragem = request.Quilometragem
                };

                await _manutencaoVeiculoRepository.AddAsync(manutencao);

                log.Information("Informação de Manutenção do Veículo {VeiculoId} inserida com sucesso. ID: {Id}.", request.VeiculoId, manutencao.Id);
                return manutencao.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar informação de manutenção do veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
