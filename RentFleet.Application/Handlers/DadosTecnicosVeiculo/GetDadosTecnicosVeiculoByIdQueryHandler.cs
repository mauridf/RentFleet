using AutoMapper;
using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosTecnicosVeiculo;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.DadosTecnicosVeiculo
{
    public class GetDadosTecnicosVeiculoByIdQueryHandler : IRequestHandler<GetDadosTecnicosVeiculoByIdQuery, DadosTecnicosVeiculoDTO>
    {
        private readonly IDadosTecnicosVeiculoRepository _tecnicoRepository;
        private readonly IMapper _mapper;

        public GetDadosTecnicosVeiculoByIdQueryHandler(IDadosTecnicosVeiculoRepository tecnicoRepository, IMapper mapper)
        {
            _tecnicoRepository = tecnicoRepository;
            _mapper = mapper;
        }

        public async Task<DadosTecnicosVeiculoDTO> Handle(GetDadosTecnicosVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("DadosTecnicosId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando os dados tecnicos ID: {Id}.", request.Id);

                var tecnico = await _tecnicoRepository.GetByIdAsync(request.Id);
                if (tecnico == null)
                {
                    log.Warning("Dados tecnicos ID {Id} não encontrado.", request.Id);
                    throw new Exception("Dados tecnicos não encontrados.");
                }

                log.Information("Dados tecnicos {Id} encontrado com sucesso.", request.Id);
                return _mapper.Map<DadosTecnicosVeiculoDTO>(tecnico);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar Dados tecnicos ID: {Id}.", request.Id);
                throw;
            }
        }
    }
}
