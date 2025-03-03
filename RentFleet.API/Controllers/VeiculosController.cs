using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Veiculo;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VeiculosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VeiculosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-veiculo-por-id/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<VeiculoDTO>> GetById(int id)
        {
            var log = Log.ForContext("VeiculoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando veículo por ID: {VeiculoId}.", id);

                var query = new GetVeiculoByIdQuery { Id = id };
                var veiculo = await _mediator.Send(query);

                log.Information("Veículo {VeiculoId} encontrado com sucesso.", id);
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo por ID: {VeiculoId}.", id);
                return NotFound("Veículo não encontrado.");
            }
        }

        [HttpGet("busca-veiculo-por-placa/{placa}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<VeiculoDTO>> GetByPlaca(string placa)
        {
            var log = Log.ForContext("Placa", placa); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando veículo por Placa: {Placa}.", placa);

                var query = new GetVeiculoByPlacaQuery { Placa = placa };
                var veiculo = await _mediator.Send(query);

                log.Information("Veículo {Placa} encontrado com sucesso.", placa);
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo por Placa: {Placa}.", placa);
                return NotFound("Veículo não encontrado.");
            }
        }

        [HttpGet("busca-veiculo-por-chassi/{chassi}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<VeiculoDTO>> GetByChassi(string chassi)
        {
            var log = Log.ForContext("Chassi", chassi); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando veículo por Chassi: {Chassi}.", chassi);

                var query = new GetVeiculoByChassiQuery { Chassi = chassi };
                var veiculo = await _mediator.Send(query);

                log.Information("Veículo {Chassi} encontrado com sucesso.", chassi);
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar veiculo por Chassi: {Chassi}.", chassi);
                return NotFound("Veículo não encontrado.");
            }
        }

        [HttpGet("todos-veiculos")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAll()
        {
            try
            {
                Log.Information("Buscando todos os veículos.");

                var query = new GetAllVeiculosQuery();
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos foram buscados com sucesso.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veiculos.");
                return StatusCode(500, "Erro interno ao buscar todos veiculos.");
            }
        }

        [HttpGet("todos-veiculos-por-ano-fabricacao-modelo/{anoFabModel}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByAnoFabModel(int anoFabModel)
        {
            try
            {
                Log.Information("Buscando todos os veículos por ano de fabricação/modelo.");

                var query = new GetAllVeiculosByAnoFabricacaoModeloQuery { AnoFabricacao = anoFabModel, AnoModelo = anoFabModel };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por ano de fabricação/modelo informado foram buscados com sucesso.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por ano fabricação/modelo.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por ano fabricação/modelo.");
            }
        }

        [HttpGet("todos-veiculos-por-combustivel/{combustivel}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByCombustivel(string combustivel)
        {
            try
            {
                Log.Information("Buscando todos os veículos por combustivel.");

                var query = new GetAllVeiculosByCombustivelQuery { Combustivel = combustivel };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por combustivel.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por combustivel.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por combustivel.");
            }
        }

        [HttpGet("todos-veiculos-por-cor/{cor}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByCor(string cor)
        {
            try
            {
                Log.Information("Buscando todos os veículos por cor.");

                var query = new GetAllVeiculosByCorQuery { Cor = cor };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por cor.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por cor.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por cor.");
            }
        }

        [HttpGet("todos-veiculos-por-marca/{marca}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByMarca(string marca)
        {
            try
            {
                Log.Information("Buscando todos os veículos por marca.");

                var query = new GetAllVeiculosByMarcaQuery { Marca = marca };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por marca.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por marca.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por marca.");
            }
        }

        [HttpGet("todos-veiculos-por-modelo/{modelo}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByModelo(string modelo)
        {
            try
            {
                Log.Information("Buscando todos os veículos por modelo.");

                var query = new GetAllVeiculosByModeloQuery { Modelo = modelo };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por modelo.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por modelo.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por modelo.");
            }
        }

        [HttpGet("todos-veiculos-por-portas/{portas}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByNumeroPortas(int portas)
        {
            try
            {
                Log.Information("Buscando todos os veículos por número de portas.");

                var query = new GetAllVeiculosByNumeroPortasQuery { NumeroPortas = portas };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por número de portas.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por número de portas.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por número de portas.");
            }
        }

        [HttpGet("todos-veiculos-por-tipo/{tipo}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByTipo(string tipo)
        {
            try
            {
                Log.Information("Buscando todos os veículos por tipo.");

                var query = new GetAllVeiculosByTipoQuery { Tipo = tipo };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por tipo.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por tipo.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por tipo.");
            }
        }

        [HttpGet("todos-veiculos-por-categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllByCategoria(string categoria)
        {
            try
            {
                Log.Information("Buscando todos os veículos por categoria.");

                var query = new GetAllVeiculosCategoriaQuery { Categoria = categoria };
                var veiculos = await _mediator.Send(query);

                Log.Information("Todos os veiculos por categoria.");
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os veículos por categoria.");
                return StatusCode(500, "Erro interno ao buscar todos os veículos por categoria.");
            }
        }

        [HttpPost("cadastrar-veiculo")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<int>> Create([FromBody] CreateVeiculoCommand command)
        {
            if (command == null)
            {
                return BadRequest("O corpo da requisição não pode ser vazio.");
            }

            var log = Log.ForContext("Veiculo", command.Modelo);

            try
            {
                log.Information("Cadastrando um novo Veículo de Modelo: {Modelo}.", command.Modelo);

                var veiculoId = await _mediator.Send(command);

                log.Information("Veículo {Modelo} criado com sucesso. ID: {veiculoId}.", command.Modelo, veiculoId);
                return Ok(veiculoId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar veículo modelo: {Modelo}.", command.Modelo);
                return BadRequest("Erro ao criar veículo.");
            }
        }

        [HttpPut("editar-veiculo")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Update([FromBody] UpdateVeiculoCommand command)
        {
            var log = Log.ForContext("veiculoId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando veículo com ID: {veiculoId}.", command.Id);

                await _mediator.Send(command);

                log.Information("Veículo {veiculoId} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar veículo com ID: {veiculoId}.", command.Id);
                return BadRequest("Erro ao atualizar veículo.");
            }
        }

        [HttpDelete("excluir-veículo/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("veiculoId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo veículo com ID: {veiculoId}.", id);

                var command = new DeleteVeiculoCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Veículo {veiculoId} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir veículo com ID: {veiculoId}.", id);
                return BadRequest("Erro ao excluir veículo.");
            }
        }
    }
}
