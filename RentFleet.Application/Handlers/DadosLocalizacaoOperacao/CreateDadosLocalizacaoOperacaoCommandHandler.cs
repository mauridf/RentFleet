using MediatR;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosLocalizacaoOperacao
{
    public class CreateDadosLocalizacaoOperacaoCommandHandler : IRequestHandler<CreateDadosLocalizacaoOperacaoCommand, int>
    {
        private readonly IDadosLocalizacaoOperacaoRepository _dadosLocOperRepository;

        public CreateDadosLocalizacaoOperacaoCommandHandler(IDadosLocalizacaoOperacaoRepository dadosLocOperRepository)
        {
            _dadosLocOperRepository = dadosLocOperRepository;
        }

        public async Task<int> Handle(CreateDadosLocalizacaoOperacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando dados de localização e operação do veículo: {VeiculoId}.", request.VeiculoId);

                var dadosLocOper = new RentFleet.Domain.Entities.DadosLocalizacaoOperacao
                {
                    VeiculoId = request.VeiculoId,
                    FilialRegistro = request.FilialRegistro,
                    StatusLocacao = request.StatusLocacao,
                    DataAquisicao = request.DataAquisicao,
                    ValorAquisicao = request.ValorAquisicao,
                    ValorLocacaoDiaria = request.ValorLocacaoDiaria,
                    Observacoes = request.Observacoes
                };

                await _dadosLocOperRepository.AddAsync(dadosLocOper);

                log.Information("Dados de localização e operação do veículo {VeiculoId} criado com sucesso. ID: {Id}.", request.VeiculoId, dadosLocOper.Id);
                return dadosLocOper.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar dados de localização e operação: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
