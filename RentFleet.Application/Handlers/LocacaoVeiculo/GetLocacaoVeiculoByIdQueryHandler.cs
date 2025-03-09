using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.LocacaoVeiculo
{
    public class GetLocacaoVeiculoByIdQueryHandler : IRequestHandler<GetLocacaoVeiculoByIdQuery, LocacaoVeiculoDTO>
    {
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;
        private readonly IMapper _mapper;

        public GetLocacaoVeiculoByIdQueryHandler(ILocacaoVeiculoRepository locacaoVeiculoRepository, IMapper mapper)
        {
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task<LocacaoVeiculoDTO> Handle(GetLocacaoVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("LocacaoVeiculo", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Locação: {Id}.", request.Id);

                var locacao = await _locacaoVeiculoRepository.GetByIdAsync(request.Id);
                if (locacao == null)
                {
                    log.Warning("Locação {Id} não encontrada.", request.Id);
                    throw new Exception("Locação não encontrada.");
                }

                log.Information("Locação {Id} encontrada com sucesso.", request.Id);

                var locacaoDTO = _mapper.Map<LocacaoVeiculoDTO>(locacao);
                log.Information("Mapeamento concluído com sucesso para locação {Id}.", request.Id);

                return locacaoDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar locação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
