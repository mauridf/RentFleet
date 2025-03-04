using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosMoto;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using Serilog;

namespace RentFleet.Application.Handlers.DadosMoto
{
    public class GetDadosMotoByIdQueryHandler : IRequestHandler<GetDadosMotoByIdQuery, DadosMotoDTO>
    {
        private readonly IDadosMotoRepository _dadosMotoRepository;
        private readonly IMapper _mapper;

        public GetDadosMotoByIdQueryHandler(IDadosMotoRepository dadosMotoRepository, IMapper mapper)
        {
            _dadosMotoRepository = dadosMotoRepository;
            _mapper = mapper;
        }

        public async Task<DadosMotoDTO> Handle(GetDadosMotoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosMotoId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados da moto por ID: {DadosMotoId}.", request.Id);

                var dadosMoto = await _dadosMotoRepository.GetByIdAsync(request.Id);
                if (dadosMoto == null)
                {
                    log.Warning("Dados da moto com ID {DadosMotoId} não encontrado.", request.Id);
                    throw new Exception("Dados da moto não encontrado.");
                }

                log.Information("Dados da moto {DadosMotoId} encontrado com sucesso.", request.Id);
                return _mapper.Map<DadosMotoDTO>(dadosMoto);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados da moto por ID: {DadosMotoId}.", request.Id);
                throw;
            }
        }
    }
}
