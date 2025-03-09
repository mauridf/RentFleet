using MediatR;
using RentFleet.Application.Commands.RegraDescontoJuros;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.RegraDescontoJuros
{
    public class CreateRegraDescontoJurosCommandHandler : IRequestHandler<CreateRegraDescontoJurosCommand, int>
    {
        private readonly IRegraDescontoJurosRepository _regraRepository;

        public CreateRegraDescontoJurosCommandHandler(IRegraDescontoJurosRepository regraRepository)
        {
            _regraRepository = regraRepository;
        }

        public async Task<int> Handle(CreateRegraDescontoJurosCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("RegraDescontoJuros", request.TipoRegra); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando Regra de Desconto e Juros: {TipoRegra}.", request.TipoRegra);

                var regra = new RentFleet.Domain.Entities.RegraDescontoJuros
                {
                    TipoVeiculo = request.TipoVeiculo,
                    Categoria = request.Categoria,
                    TipoRegra = request.TipoRegra,
                    Percentual = request.Percentual,
                    Descricao = request.Descricao
                };

                await _regraRepository.AddAsync(regra);

                log.Information("Regra de Desconto e Juros {TipoRegra} inserida com sucesso. ID: {Id}.", request.TipoRegra, regra.Id);
                return regra.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar regra de desconto e juros: {TipoRegra}.", request.TipoRegra);
                throw;
            }
        }
    }
}
