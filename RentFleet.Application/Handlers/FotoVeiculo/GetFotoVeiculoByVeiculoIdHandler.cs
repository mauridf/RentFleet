using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.FotoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.FotoVeiculo
{
    public class GetFotoVeiculoByVeiculoIdHandler : IRequestHandler<GetFotoVeiculoByVeiculoIdQuery, List<FotoVeiculoDTO>> // Alterado para lista
    {
        private readonly IFotoVeiculoRepository _fotoRepository;
        private readonly IMapper _mapper;

        public GetFotoVeiculoByVeiculoIdHandler(IFotoVeiculoRepository fotoRepository, IMapper mapper)
        {
            _fotoRepository = fotoRepository;
            _mapper = mapper;
        }

        public async Task<List<FotoVeiculoDTO>> Handle(GetFotoVeiculoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.VeiculoId);

            try
            {
                log.Information("Buscando fotos do veículo com VeiculoId: {VeiculoId}.", request.VeiculoId);

                var fotos = await _fotoRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (fotos == null || !fotos.Any())
                {
                    log.Warning("Nenhuma foto encontrada para o veículo {VeiculoId}.", request.VeiculoId);
                    return new List<FotoVeiculoDTO>();
                }

                log.Information("{Count} fotos encontradas para o veículo {VeiculoId}.", fotos.Count, request.VeiculoId);

                var fotosDTO = _mapper.Map<List<FotoVeiculoDTO>>(fotos);
                return fotosDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar fotos do veículo {VeiculoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}