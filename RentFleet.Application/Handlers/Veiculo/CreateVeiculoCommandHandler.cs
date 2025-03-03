using MediatR;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class CreateVeiculoCommandHandler : IRequestHandler<CreateVeiculoCommand, int>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public CreateVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<int> Handle(CreateVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Placa", request.Placa); // Adiciona contexto ao log

            try
            {
                log.Information("Cadastrando um novo veículo de placa : {Placa}.", request.Placa);

                var veiculo = new RentFleet.Domain.Entities.Veiculo
                {
                    Tipo = request.Tipo,
                    Categoria = request.Categoria,
                    Marca = request.Marca,
                    Modelo = request.Modelo,
                    AnoFabricacao = request.AnoFabricacao,
                    AnoModelo = request.AnoModelo,
                    Cor = request.Cor,
                    Placa = request.Placa,
                    Chassi = request.Chassi,
                    QuilometragemInicial = request.QuilometragemInicial,
                    QuilometragemAtual = request.QuilometragemAtual,
                    NumeroPortas = request.NumeroPortas,
                    CapacidadeTanque = request.CapacidadeTanque,
                    Combustivel = request.Combustivel,
                    DataCadastro = DateTime.UtcNow,
                    DataAlteracao = DateTime.UtcNow
                };

                await _veiculoRepository.AddAsync(veiculo);

                log.Information("Veículo {Placa} criado com sucesso. ID: {VeiculoId}.", request.Placa, veiculo.Id);
                return veiculo.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar o veiculo com Placa: {Placa}.", request.Placa);
                throw;
            }
        }
    }
}
