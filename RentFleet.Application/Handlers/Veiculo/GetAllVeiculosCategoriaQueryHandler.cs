using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetAllVeiculosCategoriaQueryHandler : IRequestHandler<GetAllVeiculosCategoriaQuery, IEnumerable<VeiculoDTO>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetAllVeiculosCategoriaQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> Handle(GetAllVeiculosCategoriaQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Categoria", request.Categoria); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os veículos por Categoria.", request.Categoria);

                var veiculo = await _veiculoRepository.GetAllByCategoriaAsync(request.Categoria);
                if (veiculo == null)
                {
                    log.Warning("Nenhum Veículo dessa categoria foi encontrado.", request.Categoria);
                    throw new Exception("Nenhum veículo dessa categoria foi encontrado.");
                }
                log.Information("Todos Veículos dessa categoria foram encontrados.", request.Categoria);
                return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos veículos dessa categoria.", request.Categoria);
                throw;
            }
        }
    }
}
