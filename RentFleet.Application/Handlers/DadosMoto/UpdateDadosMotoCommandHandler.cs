using MediatR;
using RentFleet.Application.Commands.DadosMoto;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosMoto
{
    public class UpdateDadosMotoCommandHandler : IRequestHandler<UpdateDadosMotoCommand>
    {
        private readonly IDadosMotoRepository _dadosMotoRepository;

        public UpdateDadosMotoCommandHandler(IDadosMotoRepository dadosMotoRepository)
        {
            _dadosMotoRepository = dadosMotoRepository;
        }

        public async Task<Unit> Handle(UpdateDadosMotoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosMoto", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando dados da moto : {Id}.", request.Id);

                var dadosMoto = await _dadosMotoRepository.GetByIdAsync(request.Id);
                if (dadosMoto == null)
                    throw new Exception("Dados da moto não encontrado.");

                dadosMoto.VeiculoId = request.VeiculoId;
                dadosMoto.TipoMoto = request.TipoMoto;
                dadosMoto.CapacidadeBagageiro = request.CapacidadeBagageiro;

                await _dadosMotoRepository.UpdateAsync(dadosMoto);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Dados da moto {Id} editado com sucesso. ID: {DadosMotoId}.", request.VeiculoId, dadosMoto.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar os dados da moto: {DadosMotoId}.", request.Id);
                throw;
            }
        }
    }
}
