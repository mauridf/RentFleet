using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosMoto;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosMoto
{
    public class GetDadosMotoByVeiculoIdQueryHandler : IRequestHandler<GetDadosMotoByVeiculoIdQuery, DadosMotoDTO>
    {
        private readonly IDadosMotoRepository _dadosMotoRepository;
        private readonly IMapper _mapper;

        public GetDadosMotoByVeiculoIdQueryHandler(IDadosMotoRepository dadosMotoRepository, IMapper mapper)
        {
            _dadosMotoRepository = dadosMotoRepository;
            _mapper = mapper;
        }

        public async Task<DadosMotoDTO> Handle(GetDadosMotoByVeiculoIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosMotoId", request.VeiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados da moto por ID: {DadosMotoId}.", request.VeiculoId);

                var dadosMoto = await _dadosMotoRepository.GetByVeiculoIdAsync(request.VeiculoId);
                if (dadosMoto == null)
                {
                    log.Warning("Dados da moto com ID {DadosMotoId} não encontrado.", request.VeiculoId);
                    throw new Exception("Dados da moto não encontrado.");
                }

                log.Information("Dados da moto {DadosMotoId} encontrado com sucesso.", request.VeiculoId);
                return _mapper.Map<DadosMotoDTO>(dadosMoto);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados da moto por ID: {DadosMotoId}.", request.VeiculoId);
                throw;
            }
        }
    }
}
