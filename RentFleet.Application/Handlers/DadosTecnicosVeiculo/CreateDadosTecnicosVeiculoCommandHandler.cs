using MediatR;
using RentFleet.Application.Commands.DadosTecnicosVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosTecnicosVeiculo
{
    public class CreateDadosTecnicosVeiculoCommandHandler : IRequestHandler<CreateDadosTecnicosVeiculoCommand, int>
    {
        private readonly IDadosTecnicosVeiculoRepository _tecnicoRepository;

        public CreateDadosTecnicosVeiculoCommandHandler(IDadosTecnicosVeiculoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
        }

        public async Task<int> Handle(CreateDadosTecnicosVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando dados tecnicos do veículo: {VeiculoId}.", request.VeiculoId);

                var tecnico = new RentFleet.Domain.Entities.DadosTecnicosVeiculo
                {
                    VeiculoId = request.VeiculoId,
                    PotenciaMotor = request.PotenciaMotor,
                    Cilindrada = request.Cilindrada,
                    Transmissao = request.Transmissao,
                    NumeroMarchas = request.NumeroMarchas,
                    Tracao = request.Tracao,
                    PesoBrutoTotal = request.PesoBrutoTotal,
                    CapacidadeCarga = request.CapacidadeCarga,
                    NumeroEixos = request.NumeroEixos
                };

                await _tecnicoRepository.AddAsync(tecnico);

                log.Information("Dados tecnicos do veículo {VeiculoId} adicionados com sucesso. ID: {Id}.", request.VeiculoId, tecnico.Id);
                return tecnico.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar dados tecnicos do veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
