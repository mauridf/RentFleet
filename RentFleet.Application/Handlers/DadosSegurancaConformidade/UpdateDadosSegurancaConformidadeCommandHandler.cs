using MediatR;
using RentFleet.Application.Commands.DadosSegurancaConformidade;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosSegurancaConformidade
{
    public class UpdateDadosSegurancaConformidadeCommandHandler : IRequestHandler<UpdateDadosSegurancaConformidadeCommand, Unit>
    {
        private readonly IDadosSegurancaConformidadeRepository _segurancaConformidadeRepository;

        public UpdateDadosSegurancaConformidadeCommandHandler(IDadosSegurancaConformidadeRepository segurancaConformidadeRepository)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
        }

        public async Task<Unit> Handle(UpdateDadosSegurancaConformidadeCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("SegurancaConformidade", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando dados de segurança e conformidade : {Id}.", request.Id);

                var segurancaConformidade = await _segurancaConformidadeRepository.GetByIdAsync(request.Id);
                if (segurancaConformidade == null)
                    throw new Exception("Dados de segurança e conformidade não encontrados.");

                segurancaConformidade.VeiculoId = request.VeiculoId;
                segurancaConformidade.DataUltimaInspecao = request.DataUltimaInspecao;
                segurancaConformidade.StatusInspecao = request.StatusInspecao;
                segurancaConformidade.NumeroSeguro = request.NumeroSeguro;
                segurancaConformidade.Seguradora = request.Seguradora;
                segurancaConformidade.ValidadeSeguro = request.ValidadeSeguro;
                segurancaConformidade.DataUltimaManutencao = request.DataUltimaManutencao;
                segurancaConformidade.ProximaManutencao = request.ProximaManutencao;
                segurancaConformidade.StatusVeiculo = request.StatusVeiculo;

                await _segurancaConformidadeRepository.UpdateAsync(segurancaConformidade);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Dados de Segurança e Conformidade do veículo {VeiculoId} editado com sucesso. ID: {Id}.", request.VeiculoId, segurancaConformidade.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar os de segurança e conformidade: {Id}.", request.Id);
                throw;
            }
        }
    }
}
