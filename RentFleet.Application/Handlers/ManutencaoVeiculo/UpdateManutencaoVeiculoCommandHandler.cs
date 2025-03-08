using MediatR;
using RentFleet.Application.Commands.ManutencaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.ManutencaoVeiculo
{
    public class UpdateManutencaoVeiculoCommandHandler : IRequestHandler<UpdateManutencaoVeiculoCommand,Unit>
    {
        private readonly IManutencaoVeiculoRepository _manutencaoVeiculoRepository;

        public UpdateManutencaoVeiculoCommandHandler(IManutencaoVeiculoRepository manutencaoVeiculoRepository)
        {
            _manutencaoVeiculoRepository = manutencaoVeiculoRepository;
        }

        public async Task<Unit> Handle(UpdateManutencaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ManutencaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando as informações da Manutenção de Veiculo : {Id}.", request.Id);

                var manutencao = await _manutencaoVeiculoRepository.GetByIdAsync(request.Id);
                if (manutencao == null)
                    throw new Exception("Informação de Manutenção de Veiculo não encontrada.");

                manutencao.VeiculoId = request.VeiculoId;
                manutencao.DataManutencao = request.DataManutencao;
                manutencao.TipoManutencao = request.TipoManutencao;
                manutencao.Descricao = request.Descricao;
                manutencao.Custo = request.Custo;
                manutencao.Quilometragem = request.Quilometragem;

                await _manutencaoVeiculoRepository.UpdateAsync(manutencao);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Informação de Manutenção do veículo {VeiculoId} editado com sucesso. ID: {Id}.", request.VeiculoId, manutencao.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar informação de manutenção: {Id}.", request.Id);
                throw;
            }
        }
    }
}
