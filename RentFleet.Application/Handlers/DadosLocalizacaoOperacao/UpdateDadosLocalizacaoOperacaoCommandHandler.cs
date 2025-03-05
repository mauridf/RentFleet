using MediatR;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosLocalizacaoOperacao
{
    public class UpdateDadosLocalizacaoOperacaoCommandHandler : IRequestHandler<UpdateDadosLocalizacaoOperacaoCommand, Unit>
    {
        private readonly IDadosLocalizacaoOperacaoRepository _dadosLocOperRepository;

        public UpdateDadosLocalizacaoOperacaoCommandHandler(IDadosLocalizacaoOperacaoRepository dadosLocOperRepository)
        {
            _dadosLocOperRepository = dadosLocOperRepository;
        }

        public async Task<Unit> Handle(UpdateDadosLocalizacaoOperacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosLocalizacaoOperacao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando dados de localização e operação : {Id}.", request.Id);

                var dadosLocOper = await _dadosLocOperRepository.GetByIdAsync(request.Id);
                if (dadosLocOper == null)
                    throw new Exception("Dados de localização e operação não encontrados.");

                dadosLocOper.VeiculoId = request.VeiculoId;
                dadosLocOper.FilialRegistro = request.FilialRegistro;
                dadosLocOper.StatusLocacao = request.StatusLocacao;
                dadosLocOper.DataAquisicao = request.DataAquisicao;
                dadosLocOper.ValorAquisicao = request.ValorAquisicao;
                dadosLocOper.ValorLocacaoDiaria = request.ValorLocacaoDiaria;
                dadosLocOper.Observacoes = request.Observacoes;

                await _dadosLocOperRepository.UpdateAsync(dadosLocOper);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Dados de localização e operação {VeiculoId} editado com sucesso. ID: {Id}.", request.VeiculoId, dadosLocOper.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar os de localização e operação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
