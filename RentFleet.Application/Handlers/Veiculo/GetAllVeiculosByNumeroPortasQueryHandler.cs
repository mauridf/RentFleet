using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByNumeroPortasQueryHandler : IRequestHandler<GetAllVeiculosByNumeroPortasQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByNumeroPortasQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByNumeroPortasQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Portas", request.NumeroPortas); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por número de portas.", request.NumeroPortas);

                var veiculo = await _veiculoRepository.GetAllByNumeroPortasAsync(request.NumeroPortas);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo foi encontrado com esse total de portas.", request.NumeroPortas);
                    throw new Exception("Nenhum veículo encontrado com esse número de portas.");
                }
                log.Information("Todos Veículos com esse número de portas foram encontrados.", request.NumeroPortas);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos com esse número de portas.", request.NumeroPortas);
                throw;
            }
        }
    }
}
