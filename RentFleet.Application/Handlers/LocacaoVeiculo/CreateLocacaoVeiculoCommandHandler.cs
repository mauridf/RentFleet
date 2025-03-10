using MediatR;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Application.Services;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class CreateLocacaoVeiculoCommandHandler : IRequestHandler<CreateLocacaoVeiculoCommand, int>
    {
        private readonly LocacaoVeiculoService _service;

        public CreateLocacaoVeiculoCommandHandler(LocacaoVeiculoService service)
        {
            _service = service;
        }

        public async Task<int> Handle(CreateLocacaoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando Locação para o Veículo: {VeiculoId}.", request.VeiculoId);

                return await _service.CriarLocacao(request);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao inserir locação para o veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
