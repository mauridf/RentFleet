using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.Veiculo
{
    public class GetVeiculoByChassiQueryHandler : IRequestHandler<GetVeiculoByChassiQuery, VeiculoDTO>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public GetVeiculoByChassiQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<VeiculoDTO> Handle(GetVeiculoByChassiQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Chassi", request.Chassi); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando o veiculo pelo chassi: {Chassi}.", request.Chassi);

                var veiculo = await _veiculoRepository.GetByChassiAsync(request.Chassi);
                if (veiculo == null)
                {
                    log.Warning("Veículo com Chassi {Chassi} não encontrado.", request.Chassi);
                    throw new Exception("Veículo não encontrado.");
                }

                log.Information("Veiculo {Chassi} encontrado com sucesso.", request.Chassi);

                var veiculoDTO = _mapper.Map<VeiculoDTO>(veiculo);
                log.Information("Mapeamento concluído com sucesso para o veiculo {Chassi}.", request.Chassi);

                return veiculoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo pelo Chassi: {Chassi}.", request.Chassi);
                throw;
            }
        }
    }
}
