using MediatR;
using RentFleet.Application.Commands.DadosCaminhao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosCaminhao
{
    public class CreateDadosCaminhaoCommandHandler : IRequestHandler<CreateDadosCaminhaoCommand, int>
    {
        private readonly IDadosCaminhaoRepository _dadosCaminhaoRepository;

        public CreateDadosCaminhaoCommandHandler(IDadosCaminhaoRepository dadosCaminhao)
        {
            _dadosCaminhaoRepository = dadosCaminhao;
        }

        public async Task<int> Handle(CreateDadosCaminhaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosCaminhao", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando dados do caminhão: {VeiculoId}.", request.VeiculoId);

                var dadosCaminhao = new RentFleet.Domain.Entities.DadosCaminhao
                {
                    VeiculoId = request.VeiculoId,
                    TipoCaminhao = request.TipoCaminhao,
                    ComprimentoCarroceria = request.ComprimentoCarroceria,
                    AlturaCarroceria = request.AlturaCarroceria,
                    LarguraCarroceria = request.LarguraCarroceria,
                    TipoCarroceria = request.TipoCarroceria
                };

                await _dadosCaminhaoRepository.AddAsync(dadosCaminhao);

                log.Information("Dados do caminhão {VeiculoId} criado com sucesso. ID: {DadosCaminhaoId}.", request.VeiculoId, dadosCaminhao.Id);
                return dadosCaminhao.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar dados do caminhão: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
