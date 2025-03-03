using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByTipoQueryHandler : IRequestHandler<GetAllVeiculosByTipoQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByTipoQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByTipoQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Tipo", request.Tipo); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por tipo.", request.Tipo);

                var veiculo = await _veiculoRepository.GetAllByTipoAsync(request.Tipo);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo desse tipo foi encontrado.", request.Tipo);
                    throw new Exception("Nenhum veículo desse tipo foi encontrado.");
                }
                log.Information("Todos Veículos desse tipo foram encontrados.", request.Tipo);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos desse tipo.", request.Tipo);
                throw;
            }
        }
    }
}
