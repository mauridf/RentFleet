using MediatR;
using RentFleet.Application.Commands.DadosTecnicosVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosTecnicosVeiculo
{
    public class UpdateDadosTecnicosVeiculoCommandHandler : IRequestHandler<UpdateDadosTecnicosVeiculoCommand>
    {
        private readonly IDadosTecnicosVeiculoRepository _tecnicoRepository;

        public UpdateDadosTecnicosVeiculoCommandHandler(IDadosTecnicosVeiculoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
        }

        public async Task<Unit> Handle(UpdateDadosTecnicosVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosTecnicos", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando dados tecnicos : {Id}.", request.Id);

                var tecnico = await _tecnicoRepository.GetByIdAsync(request.Id);
                if (tecnico == null)
                    throw new Exception("Dados tecnicos não encontrados.");

                tecnico.VeiculoId = request.VeiculoId;
                tecnico.PotenciaMotor = request.PotenciaMotor;
                tecnico.Cilindrada = request.Cilindrada;
                tecnico.Transmissao = request.Transmissao;
                tecnico.NumeroMarchas = request.NumeroMarchas;
                tecnico.Tracao = request.Tracao;
                tecnico.PesoBrutoTotal = request.PesoBrutoTotal;
                tecnico.CapacidadeCarga = request.CapacidadeCarga;
                tecnico.NumeroEixos = request.NumeroEixos;

                await _tecnicoRepository.UpdateAsync(tecnico);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Dados tecnicos do veículo {VeiculoId} editados com sucesso. ID: {Id}.", request.VeiculoId, tecnico.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar os dados tecnicos: {Id}.", request.Id);
                throw;
            }
        }
    }
}
