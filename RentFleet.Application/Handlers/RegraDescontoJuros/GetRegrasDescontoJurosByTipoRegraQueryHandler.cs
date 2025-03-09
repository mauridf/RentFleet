using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.RegraDescontoJuros;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.RegraDescontoJuros
{
    public class GetRegrasDescontoJurosByTipoRegraQueryHandler : IRequestHandler<GetRegrasDescontoJurosByTipoRegraQuery, IEnumerable<RegraDescontoJurosDTO>>
    {
        private readonly IRegraDescontoJurosRepository _regraRepository;
        private readonly IMapper _mapper;

        public GetRegrasDescontoJurosByTipoRegraQueryHandler(IRegraDescontoJurosRepository regraRepository, IMapper mapper)
        {
            _regraRepository = regraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegraDescontoJurosDTO>> Handle(GetRegrasDescontoJurosByTipoRegraQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("RegraDescontoJuros", request.TipoRegra); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos as regras de desconto e juros por Tipo.", request.TipoRegra);

                var regras = await _regraRepository.GetAllByTipoRegraAsync(request.TipoRegra);
                if (regras == null)
                {
                    log.Warning("Nenhuma regra de desconto e juros por tipo {TipoRegra} foi encontrada.", request.TipoRegra);
                    throw new Exception("Nenhuma regra de desconto e juros por tipo foi encontrada.");
                }
                log.Information("Todas as regras de desconto e juros por tipo {TipoRegra} foram encontradas.", request.TipoRegra);
                return _mapper.Map<IEnumerable<RegraDescontoJurosDTO>>(regras);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar todas as regras de desconto e juros por tipo {TipoRegra}.", request.TipoRegra);
                throw;
            }
        }
    }
}
