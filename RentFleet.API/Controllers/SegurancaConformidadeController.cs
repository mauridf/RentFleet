using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DadosSegurancaConformidade;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosSegurancaConformidade;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SegurancaConformidadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SegurancaConformidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-veiculoid/{veiculoId}")]
        public async Task<ActionResult<DadosSegurancaConformidadeDTO>> GetByVeiculoId(int veiculoId)
        {
            var log = Log.ForContext("SegurancaConformidade", veiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados de segurança e conformidade por ID: {Id}.", veiculoId);

                var query = new GetDadosSegurancaConformidadeByVeiculoIdQuery { VeiculoId = veiculoId };
                var segurancaConformidade = await _mediator.Send(query);

                log.Information("Dados de segurança e conformidade {Id} encontrado com sucesso.", veiculoId);
                return Ok(segurancaConformidade);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados de segurança e conformidade por ID: {Id}.", veiculoId);
                return NotFound("Dados de segurança e conformidade não encontrado.");
            }
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<DadosSegurancaConformidadeDTO>> GetById(int id)
        {
            var log = Log.ForContext("SegurancaConformidade", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados de segurança e conformidade por ID: {Id}.", id);

                var query = new GetDadosSegurancaConformidadeByIdQuery { Id = id };
                var segurancaConformidade = await _mediator.Send(query);

                log.Information("Dados de segurança e conformidade {Id} encontrado com sucesso.", id);
                return Ok(segurancaConformidade);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados de segurança e conformidade por ID: {Id}.", id);
                return NotFound("Dados de segurança e conformidade não encontrado.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDadosSegurancaConformidadeCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Registrando dados de segurança e conformidade do veículo: {VeiculoId}.", command.VeiculoId);

                var segurancaConformidadeId = await _mediator.Send(command);

                log.Information("Dados de segurança e conformidade do veículo {VeiculoId} registrados com sucesso. ID: {Id}.", command.VeiculoId, segurancaConformidadeId);
                return Ok(segurancaConformidadeId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar dados de segurança e conformidade do veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar dados de localizaçao e operação.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDadosSegurancaConformidadeCommand command)
        {
            var log = Log.ForContext("SegurancaConformidade", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando os dados de segurança e conformidade com ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Dados de segurança e conformidade {Id} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar os dados de segurança e conformidade com ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar os dados de segurança e conformidade.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("SegurancaConformidade", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo os dados de segurança e conformidade com ID: {Id}.", id);

                var command = new DeleteDadosSegurancaConformidadeCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Dados de segurança e conformidade {Id} excluídos com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados de segurança e conformidade com ID: {Id}.", id);
                return BadRequest("Erro ao excluir dados de segurança e conformidade.");
            }
        }
    }
}
