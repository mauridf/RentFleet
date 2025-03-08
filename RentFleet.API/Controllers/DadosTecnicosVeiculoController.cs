using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DadosTecnicosVeiculo;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosTecnicosVeiculo;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DadosTecnicosVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DadosTecnicosVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-veiculoid/{veiculoId}")]
        public async Task<ActionResult<DadosTecnicosVeiculoDTO>> GetByVeiculoId(int veiculoId)
        {
            var log = Log.ForContext("DadosTecnicos", veiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados tecnicos do Veículo ID: {VeiculoId}.", veiculoId);

                var query = new GetDadosTecnicosVeiculoByVeiculoIdQuery { VeiculoId = veiculoId };
                var tecnico = await _mediator.Send(query);

                log.Information("Dados tecnicos do veículo {VeiculoId} encontrado com sucesso.", veiculoId);
                return Ok(tecnico);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados tecnicos do veículo ID: {VeiculoId}.", veiculoId);
                return NotFound("Dados tecnicos do veículo não encontrado.");
            }
        }

        [HttpGet("busca-dados-tecnicos-por-id/{id}")]
        public async Task<ActionResult<DadosTecnicosVeiculoDTO>> GetById(int id)
        {
            var log = Log.ForContext("DadosTecnicos", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados tecnicos ID: {Id}.", id);

                var query = new GetDadosTecnicosVeiculoByIdQuery { Id = id };
                var tecnico = await _mediator.Send(query);

                log.Information("Dados tecnicos {Id} encontrado com sucesso.", id);
                return Ok(tecnico);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados tecnicos ID: {Id}.", id);
                return NotFound("Dados tecnicos não encontrados.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDadosTecnicosVeiculoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Registrando dados tecnicos do veículo: {VeiculoId}.", command.VeiculoId);

                var tecnicoId = await _mediator.Send(command);

                log.Information("Dados tecnicos do veículo {VeiculoId} registrados com sucesso. ID: {Id}.", command.VeiculoId, tecnicoId);
                return Ok(tecnicoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar dados tecnicos do veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar dados tenicos.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDadosTecnicosVeiculoCommand command)
        {
            var log = Log.ForContext("DadosTecnicos", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando os dados tecnicos com ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Dados tecnicos {Id} atualizados com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar os dados tecnicos com ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar os dados tecnicos.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("DadosTecnicos", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo os dados tecnicos com ID: {Id}.", id);

                var command = new DeleteDadosTecnicosVeiculoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Dados tecnicos {Id} excluídos com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados tecnicos com ID: {Id}.", id);
                return BadRequest("Erro ao excluir tecnicos.");
            }
        }
    }
}
