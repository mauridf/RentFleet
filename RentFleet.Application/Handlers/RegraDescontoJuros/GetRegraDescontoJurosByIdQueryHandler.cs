using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.RegraDescontoJuros;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.RegraDescontoJuros
{
    public class GetRegraDescontoJurosByIdQueryHandler : IRequestHandler<GetRegraDescontoJurosByIdQuery, RegraDescontoJurosDTO>
    {
        private readonly IRegraDescontoJurosRepository _regraRepository;
        private readonly IMapper _mapper;

        public GetRegraDescontoJurosByIdQueryHandler(IRegraDescontoJurosRepository regraRepository, IMapper mapper)
        {
            _regraRepository = regraRepository;
            _mapper = mapper;
        }

        public async Task<RegraDescontoJurosDTO> Handle(GetRegraDescontoJurosByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("RegraDescontoJuros", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Regra de Desconto e Juros: {Id}.", request.Id);

                var regra = await _regraRepository.GetByIdAsync(request.Id);
                if (regra == null)
                {
                    log.Warning("Regra de Desconto e Juros {Id} não encontrada.", request.Id);
                    throw new Exception("Regra de Desconto e Juros não encontrada.");
                }

                log.Information("Regra de Desconto e Juros {Id} encontrada com sucesso.", request.Id);

                var regraDTO = _mapper.Map<RegraDescontoJurosDTO>(regra);
                log.Information("Mapeamento concluído com sucesso para regra de desconto e juros {Id}.", request.Id);

                return regraDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar regra de desconto e juros: {Id}.", request.Id);
                throw;
            }
        }
    }
}
