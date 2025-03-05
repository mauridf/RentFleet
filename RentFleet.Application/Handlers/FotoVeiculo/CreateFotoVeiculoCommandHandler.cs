using MediatR;
using RentFleet.Application.Commands.FotoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.FotoVeiculo
{
    public class CreateFotoVeiculoCommandHandler : IRequestHandler<CreateFotoVeiculoCommand, int>
    {
        private readonly IFotoVeiculoRepository _fotoRepository;

        public CreateFotoVeiculoCommandHandler(IFotoVeiculoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }

        public async Task<int> Handle(CreateFotoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Adicionando Foto do veiculo: {VeiculoId}.", request.VeiculoId);

                var foto = new RentFleet.Domain.Entities.FotoVeiculo
                {
                    VeiculoId = request.VeiculoId,
                    UrlImagem = request.UrlImagem
                };

                await _fotoRepository.AddAsync(foto);

                log.Information("Foto do Veiculo {VeiculoId} adicionado com sucesso. ID: {Id}.", request.VeiculoId, foto.Id);
                return foto.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar foto do veículo: {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
