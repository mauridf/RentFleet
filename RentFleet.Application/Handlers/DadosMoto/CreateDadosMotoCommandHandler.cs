using MediatR;
using RentFleet.Application.Commands.DadosMoto;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosMoto
{
    public class CreateDadosMotoCommandHandler : IRequestHandler<CreateDadosMotoCommand, int>
    {
        private readonly IDadosMotoRepository _dadosMotoRepository;

        public CreateDadosMotoCommandHandler(IDadosMotoRepository dadosMoto)
        {
            _dadosMotoRepository = dadosMoto;
        }

        public async Task<int> Handle(CreateDadosMotoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosMoto", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando dados da moto: {VeiculoId}.", request.VeiculoId);

                var dadosMoto = new RentFleet.Domain.Entities.DadosMoto
                {
                    VeiculoId = request.VeiculoId,
                    TipoMoto = request.TipoMoto,
                    CapacidadeBagageiro = request.CapacidadeBagageiro
                };

                await _dadosMotoRepository.AddAsync(dadosMoto);

                log.Information("Dados da moto {VeiculoId} criado com sucesso. ID: {DadosMotoId}.", request.VeiculoId, dadosMoto.Id);
                return dadosMoto.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar dados da moto: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
