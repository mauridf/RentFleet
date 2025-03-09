using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.RegraDescontoJuros;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.RegraDescontoJuros;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegraDescontoJurosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegraDescontoJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<RegraDescontoJurosDTO>> GetById(int id)
        {
            var log = Log.ForContext("RegraDescontoJuros", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Regra de Desconto e Juros ID: {Id}.", id);

                var query = new GetRegraDescontoJurosByIdQuery { Id = id };
                var regra = await _mediator.Send(query);

                log.Information("Regra de Desconto e Juros {Id} encontrada com sucesso.", id);
                return Ok(regra);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar a regra de desconto e juros ID: {Id}.", id);
                return NotFound("Regra de desconto e juros não encontrada.");
            }
        }

        [HttpGet("listar-todas-por-tipo/{tipo}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<RegraDescontoJurosDTO>>> GetAllByTipoRegra(string tipo)
        {
            try
            {
                Log.Information("Buscando todas as regras de desconto e juros por tipo.");

                var query = new GetRegrasDescontoJurosByTipoRegraQuery { TipoRegra = tipo };
                var regras = await _mediator.Send(query);

                Log.Information("As regras de desconto e juros foram encontradas com sucesso.");
                return Ok(regras);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar as regras de desconto e juros por tipo.");
                return StatusCode(500, "Erro interno ao buscar as regras de desconto e juros por tipo.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateRegraDescontoJurosCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("RegraDescontoJuros", command.TipoVeiculo);

            try
            {
                log.Information("Registrar Regra de Desconto e Juros: {TipoRegra}.", command.TipoRegra);

                var regraId = await _mediator.Send(command);

                log.Information("Regra de Desconto e Juros do tipo {TipoRegra} registrada com sucesso. ID: {Id}.", command.TipoRegra, regraId);
                return Ok(regraId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar regra de desconto e juros para o tipo: {TipoRegra}.", command.TipoRegra);
                return BadRequest("Erro ao registrar regra de desconto e juros.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateRegraDescontoJurosCommand command)
        {
            var log = Log.ForContext("RegraDescontoJuros", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando regra de desconto e juros ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Regra de Desconto e Juros {Id} atualizada com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar regra de desconto e juros ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar regra de desconto e juros.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("RegraDescontoJuros", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo regra de desconto e juros ID: {Id}.", id);

                var command = new DeleteRegraDescontoJurosCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Regra de Desconto e Juros {Id} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir regra de desconto e juros ID: {Id}.", id);
                return BadRequest("Erro ao excluir regra de desconto e juros.");
            }
        }
    }
}
