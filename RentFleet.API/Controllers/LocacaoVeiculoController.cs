using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.LocacaoVeiculo;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.LocacaoVeiculo;
using RentFleet.Domain.Entities;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocacaoVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocacaoVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<LocacaoVeiculoDTO>> GetById(int id)
        {
            var log = Log.ForContext("Locacao", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando a Locação ID: {Id}.", id);

                var query = new GetLocacaoVeiculoByIdQuery { Id = id };
                var locacao = await _mediator.Send(query);

                log.Information("Locação {Id} encontrado com sucesso.", id);
                return Ok(locacao);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar a Locação ID: {Id}.", id);
                return NotFound("Locação não encontrada.");
            }
        }

        [HttpGet("listar-todas-por-veiculo/{veiculoId}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<LocacaoVeiculoDTO>>> GetAllByVeiculoId(int veiculoId)
        {
            try
            {
                Log.Information("Buscando todas as Locações por veículo.");

                var query = new GetAllLocacoesVeiculoByVeiculoIdQuery { VeiculoId = veiculoId };
                var locacoes = await _mediator.Send(query);

                Log.Information("As Locações foram encontrados com sucesso.");
                return Ok(locacoes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar locações por veículo.");
                return StatusCode(500, "Erro interno ao buscar locações por veículo.");
            }
        }

        [HttpGet("listar-todas-por-cliente/{clienteId}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<LocacaoVeiculoDTO>>> GetAllByClienteId(int clienteId)
        {
            try
            {
                Log.Information("Buscando todas as Locações por cliente.");

                var query = new GetAllLocacoesVeiculoByClienteIdQuery { ClienteId = clienteId };
                var locacoes = await _mediator.Send(query);

                Log.Information("As Locações foram encontrados com sucesso.");
                return Ok(locacoes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar locações por cliente.");
                return StatusCode(500, "Erro interno ao buscar locações por cliente.");
            }
        }

        [HttpGet("locados")]
        public async Task<ActionResult<List<LocacaoVeiculo>>> GetVeiculosLocados()
        {
            try
            {
                Log.Information("Buscando todos os Veículos Locados.");

                var veiculos = await _mediator.Send(new GetVeiculosLocadosQuery());

                Log.Information("Todos os Veículos Locados foram encontrados.");

                return Ok(veiculos);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Erro ao buscar veículos locados.");
                return StatusCode(500, "Erro interno ao buscar veículos locados.");
            }
        }

        [HttpGet("disponiveis")]
        public async Task<ActionResult<List<LocacaoVeiculo>>> GetVeiculosDisponiveis()
        {
            try
            {
                Log.Information("Buscando todos os Veículos Disponíveis.");

                var veiculos = await _mediator.Send(new GetVeiculosDisponiveisQuery());

                Log.Information("Todos os Veículos disponíveis foram encontrados.");

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar veículos disponíveis.");
                return StatusCode(500, "Erro interno ao buscar veículos disponíveis.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateLocacaoVeiculoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("LocacaoVeiculo", command.VeiculoId);

            try
            {
                log.Information("Registar Locação para o Veículo: {VeiculoId}.", command.VeiculoId);

                var locacaoId = await _mediator.Send(command);

                log.Information("Locação para o veículo {VeiculoId} registrada com sucesso. ID: {Id}.", command.VeiculoId, locacaoId);
                return Ok(locacaoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar locação para o veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar locação.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateLocacaoVeiculoCommand command)
        {
            var log = Log.ForContext("LocacaoVeiculo", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando locação ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Locação {Id} atualizada com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar locação ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar locação.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("LocacaoVeiculo", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo locaçao ID: {Id}.", id);

                var command = new DeleteLocacaoVeiculoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Locação {Id} excluída com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir locação ID: {Id}.", id);
                return BadRequest("Erro ao excluir locação.");
            }
        }
    }
}
