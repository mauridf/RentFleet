using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.FotoVeiculo;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.FotoVeiculo;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FotosVeiculosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FotosVeiculosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<FotoVeiculoDTO>> GetById(int id)
        {
            var log = Log.ForContext("Foto", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando a foto do veículo por ID: {Foto}.", id);

                var query = new GetFotoVeiculoByIdQuery { Id = id };
                var foto = await _mediator.Send(query);

                log.Information("Foto do veículo {Id} encontrada com sucesso.", id);
                return Ok(foto);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar foto do veiculo por ID: {Id}.", id);
                return NotFound("Foto do veículo não encontrada.");
            }
        }

        [HttpGet("listar-todas-fotos-por-veiculo/{veiculoId}")]
        public async Task<ActionResult<IEnumerable<FotoVeiculoDTO>>> GetAllByVeiculoId(int veiculoId)
        {
            try
            {
                Log.Information("Buscando todas as fotos do veículo.");

                var query = new GetFotoVeiculoByVeiculoIdQuery { VeiculoId = veiculoId };
                var fotos = await _mediator.Send(query);

                Log.Information("As fotos do veículo foram buscadas com sucesso.");
                return Ok(fotos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar as fotos do veículo.");
                return StatusCode(500, "Erro interno ao buscar fotos do veículo.");
            }
        }

        [HttpPost("adicionar-foto")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateFotoVeiculoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Adicionando foto do veículo: {VeiculoId}.", command.VeiculoId);

                var fotoId = await _mediator.Send(command);

                log.Information("Foto do Veículo {VeiculoId} adicionada com sucesso. ID: {Id}.", command.VeiculoId, fotoId);
                return Ok(fotoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar foto ao veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao adicionar foto.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateFotoVeiculoCommand command)
        {
            var log = Log.ForContext("veiculoId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando foto com ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Foto {Id} atualizada com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar foto com ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar foto.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("veiculoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo foto com ID: {Id}.", id);

                var command = new DeleteFotoVeiculoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Foto {Id} excluída com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir foto com ID: {Id}.", id);
                return BadRequest("Erro ao excluir foto.");
            }
        }
    }
}
