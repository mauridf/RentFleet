using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosQueryHandler : IRequestHandler<GetAllVeiculosQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Veiculos", request); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos.", request);

                var veiculos = await _veiculoRepository.GetAllAsync();
                if (veiculos == null)
                {
                    log.Warning("Nenhum Veículo foi encontrado.", request);
                    throw new Exception("Nenhum veículo foi encontrado.");
                }
                log.Information("Todos Veículos foram encontrados.", request);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos.", request);
                throw;
            }
        }
    }
}
