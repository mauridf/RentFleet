using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DadosMoto;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosMoto;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DadosMotoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DadosMotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<DadosMotoDTO>> GetById(int id)
        {
            var log = Log.ForContext("DadosMotoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados da moto por ID: {DadosMotoId}.", id);

                var query = new GetDadosMotoByIdQuery { Id = id };
                var dadosMoto = await _mediator.Send(query);

                log.Information("Dados da Moto {DadosMotoId} encontrado com sucesso.", id);
                return Ok(dadosMoto);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados da Moto por ID: {DadosMotoId}.", id);
                return NotFound("Dados da Moto não encontrado.");
            }
        }

        [HttpGet("busca-por-veiculoid/{veiculoId}")]
        public async Task<ActionResult<DadosMotoDTO>> GetByVeiculoId(int veiculoId)
        {
            var log = Log.ForContext("DadosMotoId", veiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados da moto por ID: {DadosMotoId}.", veiculoId);

                var query = new GetDadosMotoByVeiculoIdQuery { VeiculoId = veiculoId };
                var dadosMoto = await _mediator.Send(query);

                log.Information("Dados da Moto {DadosMotoId} encontrado com sucesso.", veiculoId);
                return Ok(dadosMoto);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados da Moto por ID: {DadosMotoId}.", veiculoId);
                return NotFound("Dados da Moto não encontrado.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDadosMotoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("DadosMoto", command.VeiculoId);

            try
            {
                log.Information("Registrar os dados da moto: {VeiculoId}.", command.VeiculoId);

                var dadosMotoId = await _mediator.Send(command);

                log.Information("Dados da Moto {veiculoId} registrados com sucesso. ID: {DadosMotoId}.", command.VeiculoId, dadosMotoId);
                return Ok(dadosMotoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar dados da Moto: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar dados da Moto.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDadosMotoCommand command)
        {
            var log = Log.ForContext("DadosMotoId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando dados da moto ID: {DadosMotoId}.", command.Id);

                await _mediator.Send(command);

                log.Information("Dados da moto {DadosMotoId} atualizados com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar dados da moto ID: {DadosMotoId}.", command.Id);
                return BadRequest("Erro ao atualizar dados da moto.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("DadosMotoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo dados da moto ID: {DadosMotoId}.", id);

                var command = new DeleteDadosMotoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Dados da moto {DadosMotoId} excluídos com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados da moto ID: {DadosMotoId}.", id);
                return BadRequest("Erro ao excluir dados da moto.");
            }
        }
    }
}
