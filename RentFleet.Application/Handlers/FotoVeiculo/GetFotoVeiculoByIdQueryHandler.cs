using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.FotoVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.FotoVeiculo
{
    public class GetFotoVeiculoByIdQueryHandler : IRequestHandler<GetFotoVeiculoByIdQuery, FotoVeiculoDTO>
    {
        private readonly IFotoVeiculoRepository _fotoRepository;
        private readonly IMapper _mapper;

        public GetFotoVeiculoByIdQueryHandler(IFotoVeiculoRepository fotoRepository, IMapper mapper)
        {
            _fotoRepository = fotoRepository;
            _mapper = mapper;
        }

        public async Task<FotoVeiculoDTO> Handle(GetFotoVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Id", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando a foto pelo Id: {Id}.", request.Id);

                var foto = await _fotoRepository.GetByIdAsync(request.Id);
                if (foto == null)
                {
                    log.Warning("Foto Id {Id} não encontrada.", request.Id);
                    throw new Exception("Foto não encontrada.");
                }

                log.Information("Foto {Id} encontrada com sucesso.", request.Id);

                var fotoDTO = _mapper.Map<FotoVeiculoDTO>(foto);
                log.Information("Mapeamento concluído com sucesso para a foto {Id}.", request.Id);

                return fotoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar foto : {Id}.", request.Id);
                throw;
            }
        }
    }
}
