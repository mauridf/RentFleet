using MediatR;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class UpdateVeiculoCommandHandler : IRequestHandler<UpdateVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Unit> Handle(UpdateVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Placa", request.Placa); // Adiciona contexto ao log

            try
            {
                log.Information("Editando veiculo com placa: {Placa}.", request.Placa);

                var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);
                if (veiculo == null)
                    throw new Exception("Veiculo não encontrado.");

                veiculo.Tipo = request.Tipo;
                veiculo.Categoria = request.Categoria;
                veiculo.Marca = request.Marca;
                veiculo.Modelo = request.Modelo;
                veiculo.AnoFabricacao = request.AnoFabricacao;
                veiculo.AnoModelo = request.AnoModelo;
                veiculo.Cor = request.Cor;
                veiculo.Placa = request.Placa;
                veiculo.Chassi = request.Chassi;
                veiculo.QuilometragemInicial = request.QuilometragemInicial;
                veiculo.QuilometragemAtual = request.QuilometragemAtual;
                veiculo.NumeroPortas = request.NumeroPortas;
                veiculo.CapacidadeTanque = request.CapacidadeTanque;
                veiculo.Combustivel = request.Combustivel;
                veiculo.DataAlteracao = DateTime.UtcNow;

                await _veiculoRepository.UpdateAsync(veiculo);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Veiculo {Placa} editado com sucesso. ID: {VeiculoId}.", request.Placa, veiculo.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar o veiculo de placa: {Placa}.", request.Placa);
                throw;
            }
        }
    }
}
