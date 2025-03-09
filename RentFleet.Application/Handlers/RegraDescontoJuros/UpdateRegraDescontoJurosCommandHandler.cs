using MediatR;
using RentFleet.Application.Commands.RegraDescontoJuros;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.RegraDescontoJuros
{
    public class UpdateRegraDescontoJurosCommandHandler : IRequestHandler<UpdateRegraDescontoJurosCommand, Unit>
    {
        private readonly IRegraDescontoJurosRepository _regraRepository;

        public UpdateRegraDescontoJurosCommandHandler(IRegraDescontoJurosRepository regraRepository)
        {
            _regraRepository = regraRepository;
        }

        public async Task<Unit> Handle(UpdateRegraDescontoJurosCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("RegraDescontoJuros", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando a Regra de Desconto e Juros : {Id}.", request.Id);

                var regra = await _regraRepository.GetByIdAsync(request.Id);
                if (regra == null)
                    throw new Exception("Regra de Desconto e Juros não encontrada.");

                regra.TipoVeiculo = request.TipoVeiculo;
                regra.Categoria = request.Categoria;
                regra.TipoRegra = request.TipoRegra;
                regra.Percentual = request.Percentual;
                regra.Descricao = request.Descricao;

                await _regraRepository.UpdateAsync(regra);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Regra de Desconto e Juros {Id} editado com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar regra de desconto e juros: {Id}.", request.Id);
                throw;
            }
        }
    }
}
