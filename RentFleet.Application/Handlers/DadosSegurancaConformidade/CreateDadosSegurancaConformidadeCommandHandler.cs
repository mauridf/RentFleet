using MediatR;
using RentFleet.Application.Commands.DadosSegurancaConformidade;
using RentFleet.Domain.Interfaces;
using Serilog;
using System.Runtime.CompilerServices;

namespace RentFleet.Application.Handlers.DadosSegurancaConformidade
{
    public class CreateDadosSegurancaConformidadeCommandHandler : IRequestHandler<CreateDadosSegurancaConformidadeCommand, int>
    {
        private readonly IDadosSegurancaConformidadeRepository _segurancaConformidadeRepository;

        public CreateDadosSegurancaConformidadeCommandHandler(IDadosSegurancaConformidadeRepository segurancaConformidadeRepository)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
        }

        public async Task<int> Handle(CreateDadosSegurancaConformidadeCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando dados de segurança e conformidade do veículo: {VeiculoId}.", request.VeiculoId);

                var segurancaConformidade = new RentFleet.Domain.Entities.DadosSegurancaConformidade
                {
                    VeiculoId = request.VeiculoId,
                    DataUltimaInspecao = request.DataUltimaInspecao,
                    StatusInspecao = request.StatusInspecao,
                    NumeroSeguro = request.NumeroSeguro,
                    Seguradora = request.Seguradora,
                    ValidadeSeguro = request.ValidadeSeguro,
                    DataUltimaManutencao = request.DataUltimaManutencao,
                    ProximaManutencao = request.ProximaManutencao,
                    StatusVeiculo = request.StatusVeiculo
                };

                await _segurancaConformidadeRepository.AddAsync(segurancaConformidade);

                log.Information("Dados de segurança e conformidade do veículo {VeiculoId} criado com sucesso. ID: {Id}.", request.VeiculoId, segurancaConformidade.Id);
                return segurancaConformidade.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar dados de segurança e conformidade: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
