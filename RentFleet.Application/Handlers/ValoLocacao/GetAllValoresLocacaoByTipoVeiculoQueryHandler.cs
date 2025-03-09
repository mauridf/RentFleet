using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ValorLocacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ValoLocacao
{
    public class GetAllValoresLocacaoByTipoVeiculoQueryHandler : IRequestHandler<GetAllValoresLocacaoByTipoVeiculoQuery,IEnumerable<ValorLocacaoDTO>>
    {
        private readonly IValorLocacaoRepository _valorLocacaoRepository;
        private readonly IMapper _mapper;

        public GetAllValoresLocacaoByTipoVeiculoQueryHandler(IValorLocacaoRepository valorLocacaoRepository, IMapper mapper)
        {
            _valorLocacaoRepository = valorLocacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValorLocacaoDTO>> Handle(GetAllValoresLocacaoByTipoVeiculoQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ValorLocacao", request.TipoVeiculo); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os valores de locação por tipo de veiculo.", request.TipoVeiculo);

                var valores = await _valorLocacaoRepository.GetAllByTipoVeiculoAsync(request.TipoVeiculo);
                if (valores == null)
                {
                    log.Warning("Nenhum valor locação por tipo de veículo {TipoVeiculo} foi encontrada.", request.TipoVeiculo);
                    throw new Exception("Nenhum valor locação por tipo de veiculo foi encontrada.");
                }
                log.Information("Todos os valores de locação por tipo de veículo {TipoVeiculo} foram encontrados.", request.TipoVeiculo);
                return _mapper.Map<IEnumerable<ValorLocacaoDTO>>(valores);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todos os valores de locação por tipo de veiculo {TipoVeiculo}.", request.TipoVeiculo);
                throw;
            }
        }
    }
}
