using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetVeiculoByIdQueryHandler : IRequestHandler<GetVeiculoByIdQuery, VeiculoDTO>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetVeiculoByIdQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<VeiculoDTO> Handle(GetVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("VeiculoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando o veiculo pelo id: {VeiculoId}.", request.Id);

                var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);
                if (veiculo == null)
                {
                    log.Warning("Veículo com Id {VeiculoId} não encontrado.", request.Id);
                    throw new Exception("Veículo não encontrado.");
                }

                log.Information("Veiculo {VeiculoId} encontrado com sucesso.", request.Id);

                var veiculoDTO = _mapper.Map<VeiculoDTO>(veiculo);
                log.Information("Mapeamento concluído com sucesso para o veiculo {VeiculoId}.", request.Id);

                return veiculoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo pelo Id: {VeiculoId}.", request.Id);
                throw;
            }
        }
    }
}
