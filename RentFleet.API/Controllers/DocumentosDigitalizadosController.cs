using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.DocumentoDigitalizado;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.DocumentoDigitalizado;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentosDigitalizadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentosDigitalizadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        public async Task<ActionResult<DocumentoDigitalizadoDTO>> GetById(int id)
        {
            var log = Log.ForContext("Documento", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando o documento do veículo por ID: {Documento}.", id);

                var query = new GetDocumentoDigitalizadoByIdQuery { Id = id };
                var documento = await _mediator.Send(query);

                log.Information("Documento do veículo {Id} encontrado com sucesso.", id);
                return Ok(documento);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar documento do veiculo por ID: {Id}.", id);
                return NotFound("Documento do veículo não encontrado.");
            }
        }

        [HttpGet("lista-todos-documentos-por-veiculo/{veiculoId}")]
        public async Task<ActionResult<IEnumerable<DocumentoDigitalizadoDTO>>> GetAllByVeiculoId(int veiculoId)
        {
            try
            {
                Log.Information("Buscando todos os documentos do veículo.");

                var query = new GetDocumentoDigitalizadoByVeiculoIdQuery { VeiculoId = veiculoId };
                var documentos = await _mediator.Send(query);

                Log.Information("Os documentos do veículo foram buscados com sucesso.");
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar os documentos do veículo.");
                return StatusCode(500, "Erro interno ao buscar documentod do veículo.");
            }
        }

        [HttpPost("adicionar-documento")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDocumentoDigitalizadoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.VeiculoId);

            try
            {
                log.Information("Adicionando documento do veículo: {VeiculoId}.", command.VeiculoId);

                var documentoId = await _mediator.Send(command);

                log.Information("Documento do Veículo {VeiculoId} adicionado com sucesso. ID: {Id}.", command.VeiculoId, documentoId);
                return Ok(documentoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao adicionar documento ao veículo: {VeiculoId}.", command.VeiculoId);
                return BadRequest("Erro ao adicionar documento.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateDocumentoDigitalizadoCommand command)
        {
            var log = Log.ForContext("Id", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando documento com ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Documento {Id} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar documento com ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar documento.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("veiculoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo documento com ID: {Id}.", id);

                var command = new DeleteDocumentoDigitalizadoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Documento {Id} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir documento com ID: {Id}.", id);
                return BadRequest("Erro ao excluir documento.");
            }
        }
    }
}
