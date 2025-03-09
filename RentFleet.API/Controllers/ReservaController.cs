using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.Reserva;
using RentFleet.Application.Commands.ValorLocacao;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Reserva;
using RentFleet.Application.Queries.ValorLocacao;
using RentFleet.Domain.Entities;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<ReservaDTO>> GetById(int id)
        {
            var log = Log.ForContext("Reserva", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando a Reserva ID: {Id}.", id);

                var query = new GetReservaByIdQuery { Id = id };
                var reserva = await _mediator.Send(query);

                log.Information("Reserva {Id} encontrado com sucesso.", id);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar a Reserva ID: {Id}.", id);
                return NotFound("Reserva não encontrada.");
            }
        }

        [HttpGet("listar-todas-por-veiculo/{veiculoId}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetAllByVeiculoId(int veiculoId)
        {
            try
            {
                Log.Information("Buscando todas as Reservas por veículo.");

                var query = new GetAllReservasByVeiculoIdQuery { VeiculoId = veiculoId };
                var reservas = await _mediator.Send(query);

                Log.Information("As Reservas foram encontrados com sucesso.");
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar reservas por veículo.");
                return StatusCode(500, "Erro interno ao buscar reservas por veículo.");
            }
        }

        [HttpGet("listar-todas-por-cliente/{clienteId}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetAllByClienteId(int clienteId)
        {
            try
            {
                Log.Information("Buscando todas as Reservas por cliente.");

                var query = new GetAllReservasByClienteIdQuery { ClienteId = clienteId };
                var reservas = await _mediator.Send(query);

                Log.Information("As Reservas foram encontrados com sucesso.");
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar reservas por cliente.");
                return StatusCode(500, "Erro interno ao buscar reservas por cliente.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateReservaCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Reserva", command.VeiculoId);

            try
            {
                log.Information("Registar Reserva para o Veículo: {VeiculoId}.", command.VeiculoId);

                var reservaId = await _mediator.Send(command);

                log.Information("Reserva para o veículo {VeiculoId} registrado com sucesso. ID: {Id}.", command.VeiculoId, reservaId);
                return Ok(reservaId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar reserva para o veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao registrar reserva.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateReservaCommand command)
        {
            var log = Log.ForContext("Reserva", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando reserva ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Reserva {Id} atualizada com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar reserva ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar reserva.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("ValorLocacao", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo reserva ID: {Id}.", id);

                var command = new DeleteReservaCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Reserva {Id} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir reserva ID: {Id}.", id);
                return BadRequest("Erro ao excluir reserva.");
            }
        }
    }
}
