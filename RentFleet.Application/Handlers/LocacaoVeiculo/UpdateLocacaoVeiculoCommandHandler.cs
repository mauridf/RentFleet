using MediatR;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Application.Services;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class UpdateLocacaoVeiculoCommandHandler : IRequestHandler<UpdateLocacaoVeiculoCommand,Unit>
    {
        private readonly LocacaoVeiculoService _service;

        public UpdateLocacaoVeiculoCommandHandler(LocacaoVeiculoService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(UpdateLocacaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando a Locação : {Id}.", request.Id);

                await _service.AtualizarLocacao(request);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Locação {Id} editada com sucesso.", request.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar Locação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
