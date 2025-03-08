using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.ManutencaoVeiculo;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.ManutencaoVeiculo;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManutencaoVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManutencaoVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<ManutencaoVeiculoDTO>> GetById(int id)
        {
            var log = Log.ForContext("ManutencaoVeiculo", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando informação de manutenção ID: {Id}.", id);

                var query = new GetManutencaoVeiculoByIdQuery { Id = id };
                var manutencao = await _mediator.Send(query);

                log.Information("Informação de Manutenção de Veículo {Id} encontrada com sucesso.", id);
                return Ok(manutencao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar informação de manutenção ID: {Id}.", id);
                return NotFound("informação de manutenção não encontrados.");
            }
        }

        [HttpGet("listar-todas-por-veiculo/{veiculoId}")]
        public async Task<ActionResult<IEnumerable<ManutencaoVeiculoDTO>>> GetAllByVeiculoId(int veiculoId)
        {
            try
            {
                Log.Information("Buscando todos as manutenções do veículo.");

                var query = new GetAllManutencoesVeiculoByVeiculoIdQuery { VeiculoId = veiculoId };
                var manutencoes = await _mediator.Send(query);

                Log.Information("As manutenções do veículo foram encontradas com sucesso.");
                return Ok(manutencoes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar as manutenções do veículo.");
                return StatusCode(500, "Erro interno ao buscar as manutenções do veículo.");
            }
        }

        [HttpGet("listar-todas-por-tipo/{tipo}")]
        public async Task<ActionResult<IEnumerable<ManutencaoVeiculoDTO>>> GetAllByTipoManutencao(string tipo)
        {
            try
            {
                Log.Information("Buscando todos as manutenções por tipo.");

                var query = new GetAllManutencoesVeiculoByTipoManutencaoQuery { TipoManutencao = tipo };
                var manutencoes = await _mediator.Send(query);

                Log.Information("As manutenções do veículo foram encontradas com sucesso.");
                return Ok(manutencoes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar as manutenções do veículo.");
                return StatusCode(500, "Erro interno ao buscar as manutenções do veículo.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateManutencaoVeiculoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Registrar Manutenção feita no veículo: {VeiculoId}.", command.VeiculoId);

                var manutencaoId = await _mediator.Send(command);

                log.Information("Manutencao do veículo {VeiculoId} registrada com sucesso. ID: {Id}.", command.VeiculoId, manutencaoId);
                return Ok(manutencaoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar manutenção feita no veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar manutenção do veículo.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateManutencaoVeiculoCommand command)
        {
            var log = Log.ForContext("Manutencao", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando registro de manutenção ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Registro de Manutenção {Id} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar registro de manutenção ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar registro de manutenção de veiculo.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("Manutencao", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo registro de manutenção ID: {Id}.", id);

                var command = new DeleteVeiculoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Registro de Manutenção {Id} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir registro de manutenção ID: {Id}.", id);
                return BadRequest("Erro ao excluir registro de manutenção.");
            }
        }
    }
}
