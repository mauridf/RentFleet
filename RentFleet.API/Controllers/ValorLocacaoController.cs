using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.RegraDescontoJuros;
using RentFleet.Application.Commands.ValorLocacao;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.RegraDescontoJuros;
using RentFleet.Application.Queries.ValorLocacao;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValorLocacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValorLocacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-por-id/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<ValorLocacaoDTO>> GetById(int id)
        {
            var log = Log.ForContext("ValorLocacao", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando Valor de Locação ID: {Id}.", id);

                var query = new GetValorLocacaoByIdQuery { Id = id };
                var valor = await _mediator.Send(query);

                log.Information("Valor de Locação {Id} encontrado com sucesso.", id);
                return Ok(valor);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar o valor de locação ID: {Id}.", id);
                return NotFound("Valor de Locação não encontrado.");
            }
        }

        [HttpGet("listar-todas-por-tipo-de-veiculo/{tipoVeiculo}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ValorLocacaoDTO>>> GetAllByTipoVeiculo(string tipoVeiculo)
        {
            try
            {
                Log.Information("Buscando todos os valores de locação por tipo de veículo.");

                var query = new GetAllValoresLocacaoByTipoVeiculoQuery { TipoVeiculo = tipoVeiculo };
                var valores = await _mediator.Send(query);

                Log.Information("Os Valores de Locação foram encontrados com sucesso.");
                return Ok(valores);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar os valores de locação por tipo de veículo.");
                return StatusCode(500, "Erro interno ao buscar os valores de locação por tipo de veículo.");
            }
        }

        [HttpPost("registrar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateValorLocacaoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("ValorLocacao", command.TipoVeiculo);

            try
            {
                log.Information("Registar Valor de Locação para o Tipo de Veículo: {TipoVeiculo}.", command.TipoVeiculo);

                var valorId = await _mediator.Send(command);

                log.Information("Valor de Locação do tipo de veículo {TipoVeiculo} registrado com sucesso. ID: {Id}.", command.TipoVeiculo, valorId);
                return Ok(valorId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao registrar valor de locação para o tipo de veículo: {TipoVeiculo}.", command.TipoVeiculo);
                return BadRequest("Erro ao registrar valor de locação.");
            }
        }

        [HttpPut("editar")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateValorLocacaoCommand command)
        {
            var log = Log.ForContext("ValorLocacao", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Editando valor de locação ID: {Id}.", command.Id);

                await _mediator.Send(command);

                log.Information("Valor de Locação {Id} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar valor de locação ID: {Id}.", command.Id);
                return BadRequest("Erro ao atualizar valor de locação.");
            }
        }

        [HttpDelete("excluir/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("ValorLocacao", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo valor de locação ID: {Id}.", id);

                var command = new DeleteValorLocacaoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Valor de Locação {Id} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir valor de locação ID: {Id}.", id);
                return BadRequest("Erro ao excluir valor de locação.");
            }
        }
    }
}
