using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetVeiculoByPlacaQueryHandler : IRequestHandler<GetVeiculoByPlacaQuery, VeiculoDTO>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetVeiculoByPlacaQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<VeiculoDTO> Handle(GetVeiculoByPlacaQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Placa", request.Placa); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando o veiculo pela placa: {Placa}.", request.Placa);

                var veiculo = await _veiculoRepository.GetByPlacaAsync(request.Placa);
                if (veiculo == null)
                {
                    log.Warning("Veículo com Placa {Placa} não encontrado.", request.Placa);
                    throw new Exception("Veículo não encontrado.");
                }

                log.Information("Veiculo {Placa} encontrado com sucesso.", request.Placa);

                var veiculoDTO = _mapper.Map<VeiculoDTO>(veiculo);
                log.Information("Mapeamento concluído com sucesso para o veiculo {Placa}.", request.Placa);

                return veiculoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo pela Placa: {Placa}.", request.Placa);
                throw;
            }
        }
    }
}
