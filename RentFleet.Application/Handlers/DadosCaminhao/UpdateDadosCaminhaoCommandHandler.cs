using MediatR;
using RentFleet.Application.Commands.DadosCaminhao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosCaminhao
{
    public class UpdateDadosCaminhaoCommandHandler : IRequestHandler<UpdateDadosCaminhaoCommand, Unit>
    {
        private readonly IDadosCaminhaoRepository _dadosCaminhaoRepository;

        public UpdateDadosCaminhaoCommandHandler(IDadosCaminhaoRepository dadosCaminhaoRepository)
        {
            _dadosCaminhaoRepository = dadosCaminhaoRepository;
        }

        public async Task<Unit> Handle(UpdateDadosCaminhaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosCaminhao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando dados do caminhão : {Id}.", request.Id);

                var dadosCaminhao = await _dadosCaminhaoRepository.GetByIdAsync(request.Id);
                if (dadosCaminhao == null)
                    throw new Exception("Dados do caminhão não encontrado.");

                dadosCaminhao.VeiculoId = request.VeiculoId;
                dadosCaminhao.TipoCaminhao = request.TipoCaminhao;
                dadosCaminhao.ComprimentoCarroceria = request.ComprimentoCarroceria;
                dadosCaminhao.AlturaCarroceria = request.AlturaCarroceria;
                dadosCaminhao.LarguraCarroceria = request.LarguraCarroceria;
                dadosCaminhao.TipoCarroceria = request.TipoCarroceria;

                await _dadosCaminhaoRepository.UpdateAsync(dadosCaminhao);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Dados do caminhão {Id} editado com sucesso. ID: {DadosCaminhaoId}.", request.VeiculoId, dadosCaminhao.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar os dados do caminhão: {DadosCaminhaoId}.", request.Id);
                throw;
            }
        }
    }
}
