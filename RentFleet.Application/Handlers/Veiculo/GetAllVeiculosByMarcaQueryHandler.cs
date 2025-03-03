using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByMarcaQueryHandler : IRequestHandler<GetAllVeiculosByMarcaQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByMarcaQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByMarcaQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Marca", request.Marca); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos pela marca.", request.Marca);

                var veiculo = await _veiculoRepository.GetAllByMarcaAsync(request.Marca);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo dessa marca foi encontrado.", request.Marca);
                    throw new Exception("Nenhum Veículo dessa marca foi encontrado.");
                }
                log.Information("Todos Veículos dessa marca foram encontrados.", request.Marca);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos dessa marca.", request.Marca);
                throw;
            }
        }
    }
}
