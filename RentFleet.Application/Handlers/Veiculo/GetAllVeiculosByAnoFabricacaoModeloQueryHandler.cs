using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByAnoFabricacaoModeloQueryHandler : IRequestHandler<GetAllVeiculosByAnoFabricacaoModeloQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByAnoFabricacaoModeloQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByAnoFabricacaoModeloQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("AnoFabricao", request.AnoFabricacao); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por ano de fabricação ou ano modelo.", request.AnoFabricacao);

                var veiculo = await _veiculoRepository.GetAllByAnoFabricacaoModeloAsync(request.AnoFabricacao);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo desse ano de fabricação foi encontrado.", request.AnoFabricacao);
                    throw new Exception("Nenhum veículo desse ano de fabricação foi encontrado.");
                }
                log.Information("Todos Veículos desse ano de fabricação foram encontrados.", request.AnoFabricacao);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos desse ano de fabricação.", request.AnoFabricacao);
                throw;
            }
        }
    }
}
