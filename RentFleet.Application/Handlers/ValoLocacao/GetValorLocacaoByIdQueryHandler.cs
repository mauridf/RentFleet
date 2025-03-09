using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ValorLocacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ValoLocacao
{
    public class GetValorLocacaoByIdQueryHandler : IRequestHandler<GetValorLocacaoByIdQuery, ValorLocacaoDTO>
    {
        private readonly IValorLocacaoRepository _valorLocacaoRepository;
        private readonly IMapper _mapper;

        public GetValorLocacaoByIdQueryHandler(IValorLocacaoRepository valorLocacaoRepository, IMapper mapper)
        {
            _valorLocacaoRepository = valorLocacaoRepository;
            _mapper = mapper;
        }

        public async Task<ValorLocacaoDTO> Handle(GetValorLocacaoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ValorLocacao", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Valor de Locação: {Id}.", request.Id);

                var valor = await _valorLocacaoRepository.GetByIdAsync(request.Id);
                if (valor == null)
                {
                    log.Warning("Valor de Locação {Id} não encontrado.", request.Id);
                    throw new Exception("Valor de Locação não encontrada.");
                }

                log.Information("Valor de Locação {Id} encontrado com sucesso.", request.Id);

                var valorDTO = _mapper.Map<ValorLocacaoDTO>(valor);
                log.Information("Mapeamento concluído com sucesso para valor de locação {Id}.", request.Id);

                return valorDTO;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar valor de locação: {Id}.", request.Id);
                throw;
            }
        }
    }
}
