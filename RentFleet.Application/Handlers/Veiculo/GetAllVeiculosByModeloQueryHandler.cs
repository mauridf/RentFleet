using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByModeloQueryHandler : IRequestHandler<GetAllVeiculosByModeloQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByModeloQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByModeloQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Modelo", request.Modelo); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por modelo.", request.Modelo);

                var veiculo = await _veiculoRepository.GetAllByModeloAsync(request.Modelo);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo desse modelo foi encontrado.", request.Modelo);
                    throw new Exception("Nenhum Veículo desse modelo foi encontrado.");
                }
                log.Information("Todos Veículos desse modelo foram encontrados.", request.Modelo);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos desse modelo.", request.Modelo);
                throw;
            }
        }
    }
}
