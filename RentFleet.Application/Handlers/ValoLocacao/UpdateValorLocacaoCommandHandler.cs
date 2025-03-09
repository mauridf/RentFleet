using MediatR;
using RentFleet.Application.Commands.ValorLocacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ValoLocacao
{
    public class UpdateValorLocacaoCommandHandler : IRequestHandler<UpdateValorLocacaoCommand, Unit>
    {
        private readonly IValorLocacaoRepository _valorLocacaoRepository;

        public UpdateValorLocacaoCommandHandler(IValorLocacaoRepository valorLocacaoRepository)
        {
            _valorLocacaoRepository = valorLocacaoRepository;
        }

        public async Task<Unit> Handle(UpdateValorLocacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ValorLocacao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando o Valor de Locação : {Id}.", request.Id);

                var valor = await _valorLocacaoRepository.GetByIdAsync(request.Id);
                if (valor == null)
                    throw new Exception("Valor de Locação não encontrado.");

                valor.TipoVeiculo = request.TipoVeiculo;
                valor.Categoria = request.Categoria;
                valor.ValorDiaria = request.ValorDiaria;

                await _valorLocacaoRepository.UpdateAsync(valor);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Valor de Locação {Id} editado com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar Valor de Locação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
