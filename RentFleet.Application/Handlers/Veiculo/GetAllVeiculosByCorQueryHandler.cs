using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosByCorQueryHandler : IRequestHandler<GetAllVeiculosByCorQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosByCorQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosByCorQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Cor", request.Cor); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos pela cor.", request.Cor);

                var veiculo = await _veiculoRepository.GetAllByCorAsync(request.Cor);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo com essa cor foi encontrado.", request.Cor);
                    throw new Exception("Nenhum Veículo com essa cor foi encontrado.");
                }
                log.Information("Todos Veículos com essa cor foram encontrados.", request.Cor);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos com essa cor.", request.Cor);
                throw;
            }
        }
    }
}
