using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosCombustivelQueryHandler : IRequestHandler<GetAllVeiculosByCombustivelQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosCombustivelQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByCombustivelQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Combustível", request.Combustivel); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por combustível.", request.Combustivel);

                var veiculo = await _veiculoRepository.GetAllByCombustivelAsync(request.Combustivel);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo com esse combustível foi encontrado.", request.Combustivel);
                    throw new Exception("Nenhum Veículo com esse combustível foi encontrado.");
                }
                log.Information("Todos Veículos com esse combustível foram encontrados.", request.Combustivel);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos com esse combustível.", request.Combustivel);
                throw;
            }
        }
    }
}
