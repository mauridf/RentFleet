using MediatR;
using RentFleet.Application.Commands.FotoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.FotoVeiculo
{
    public class UpdateFotoVeiculoCommandHandler : IRequestHandler<UpdateFotoVeiculoCommand>
    {
        private readonly IFotoVeiculoRepository _fotoRepository;

        public UpdateFotoVeiculoCommandHandler(IFotoVeiculoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }

        public async Task<Unit> Handle(UpdateFotoVeiculoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Foto", request.Id); // Adiciona contexto ao log
            try
            {
                log.Information("Editando foto: {Id}.", request.Id);

                var foto = await _fotoRepository.GetByIdAsync(request.Id);
                if (foto == null)
                    throw new Exception("Foto não encontrada.");

                foto.VeiculoId = request.Id;
                foto.UrlImagem = request.UrlImagem;

                await _fotoRepository.UpdateAsync(foto);

                // Retorna Unit.Value para indicar que o comando foi executado com sucesso
                log.Information("Foto do veículo {VeiculoId} editada com sucesso. ID: {Id}.", request.VeiculoId, foto.Id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao editar a foto: {Documento}.", request.Id);
                throw;
            }
        }
    }
}
