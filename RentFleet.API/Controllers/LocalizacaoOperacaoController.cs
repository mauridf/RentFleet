using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DadosLocalizacaoOperacao;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocalizacaoOperacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocalizacaoOperacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-veiculoid/{veiculoId}")]
        public async Task<ActionResult<DadosLocalizacaoOperacaoDTO>> GetByVeiculoId(int veiculoId)
        {
            var log = Log.ForContext("DadosLocOper", veiculoId); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados de localização e operação por ID: {Id}.", veiculoId);

                var query = new GetDadosLocalizacaoOperacaoByVeiculoIdQuery { VeiculoId = veiculoId };
                var dadosLocOper = await _mediator.Send(query);

                log.Information("Dados de localização e operação {Id} encontrado com sucesso.", veiculoId);
                return Ok(dadosLocOper);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados de localização e operação por ID: {Id}.", veiculoId);
                return NotFound("Dados de localização e operação não encontrado.");
            }
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<DadosLocalizacaoOperacaoDTO>> GetById(int id)
        {
            var log = Log.ForContext("DadosLocOper", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando dados de localização e operação por ID: {Id}.", id);

                var query = new GetDadosLocalizacaoOperacaoByIdQuery { Id = id };
                var dadosLocOper = await _mediator.Send(query);

                log.Information("Dados de localização e operação {Id} encontrado com sucesso.", id);
                return Ok(dadosLocOper);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar dados de localização e operação por ID: {Id}.", id);
                return NotFound("Dados de localização e operação não encontrado.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDadosLocalizacaoOperacaoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Registrando dados de localização e operação do veículo: {VeiculoId}.", command.VeiculoId);

                var dadosLocOperId = await _mediator.Send(command);

                log.Information("Dados de localização e operação do veículo {VeiculoId} registrados com sucesso. ID: {Id}.", command.VeiculoId, dadosLocOperId);
                return Ok(dadosLocOperId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar dados de localização e operação do veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar dados de localizaçao e operação.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDadosLocalizacaoOperacaoCommand command)
        {
            var log = Log.ForContext("DadosLocOper", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando os dados de localização e operação com ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Dados de localização e operação {Id} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar os dados de localização e operação com ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar os dados de localização e operação.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("DadosLocOper", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo os dados de localização e operação com ID: {Id}.", id);

                var command = new DeleteDadosLocalizacaoOperacaoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Dados de localização e operação {Id} excluídos com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir dados de localização e operação com ID: {Id}.", id);
                return BadRequest("Erro ao excluir dados de localização e operação.");
            }
        }
    }
}
