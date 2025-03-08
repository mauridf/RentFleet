using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DadosCaminhao;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosCaminhao;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DadosCaminhaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DadosCaminhaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<DadosCaminhaoDTO>> GetById(int id)
        {
            var log = Log.ForContext("DadosCaminhaoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados do caminhão por ID: {DadosCaminhaoId}.", id);

                var query = new GetDadosCaminhaoByIdQuery { Id = id };
                var dadosCaminhao = await _mediator.Send(query);

                log.Information("Dados do Caminhão {DadosCaminhaoId} encontrado com sucesso.", id);
                return Ok(dadosCaminhao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados do Caminhão por ID: {DadosCaminhaoId}.", id);
                return NotFound("Dados do Caminhão não encontrado.");
            }
        }

        [HttpGet("busca-por-veiculoid/{veiculoId}")]
        public async Task<ActionResult<DadosCaminhaoDTO>> GetByVeiculoId(int veiculoId)
        {
            var log = Log.ForContext("DadosCaminhaoId", veiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados do caminhão por ID: {DadosCaminhaoId}.", veiculoId);

                var query = new GetDadosCaminhaoByVeiculoIdQuery { VeiculoId = veiculoId };
                var dadosCaminhao = await _mediator.Send(query);

                log.Information("Dados do Caminhão {DadosCaminhaoId} encontrado com sucesso.", veiculoId);
                return Ok(dadosCaminhao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados do Caminhão por ID: {DadosCaminhaoId}.", veiculoId);
                return NotFound("Dados do Caminhão não encontrado.");
            }
        }

        [HttpPost("registrar-dados")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDadosCaminhaoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("DadosCaminhao", command.VeiculoId);

            try
            {
                log.Information("Registrar os dados do Caminhão: {VeiculoId}.", command.VeiculoId);

                var dadosCaminhaoId = await _mediator.Send(command);

                log.Information("Dados do Caminhão {VeiculoId} registrado com sucesso. ID: {DadosCaminhaoId}.", command.VeiculoId, dadosCaminhaoId);
                return Ok(dadosCaminhaoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar os dados do caminhão: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar os dados do caminhão.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDadosCaminhaoCommand command)
        {
            var log = Log.ForContext("DadosCaminhaoId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando dados do caminhão com ID: {DadosCaminhaoId}.", command.Id);

                await _mediator.Send(command);

                log.Information("Dados do Caminhão {DadosCaminhaoId} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar dados do caminhão ID: {DadosCaminhaoId}.", command.Id);
                return BadRequest("Erro ao atualizar os dados do caminhão.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("DadosCaminhaoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados do caminhão ID: {DadosCaminhaoId}.", id);

                var command = new DeleteDadosCaminhaoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Dados do caminhão {DadosCaminhaoId} excluídos com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados do caminhão ID: {DadosCaminhaoId}.", id);
                return BadRequest("Erro ao excluir dados do caminhão.");
            }
        }
    }
}
