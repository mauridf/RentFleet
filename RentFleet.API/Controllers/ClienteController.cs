using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands.Clientes;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries.Cliente;
using Serilog;

namespace RentFleet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-cliente-por-id/{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var log = Log.ForContext("ClienteId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por ID: {ClienteId}.", id);

                var query = new GetClienteByIdQuery { Id = id };
                var cliente = await _mediator.Send(query);

                log.Information("Cliente {ClienteId} encontrado com sucesso.", id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por ID: {ClienteId}.", id);
                return NotFound("Cliente não encontrado.");
            }
        }

        [HttpGet("busca-cliente-pelo-nome/{nome}")]
        public async Task<ActionResult<ClienteDTO>> GetByNome(string nome)
        {
            var log = Log.ForContext("Nome", nome); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por nome: {Nome}.", nome);

                var query = new GetClienteByNomeQuery { Nome = nome };
                var cliente = await _mediator.Send(query);

                log.Information("Cliente com nome {Nome} encontrado com sucesso.", nome);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por nome: {Nome}.", nome);
                return NotFound("Cliente não encontrado.");
            }
        }

        [HttpGet("busca-cliente-por-email/{email}")]
        public async Task<ActionResult<ClienteDTO>> GetByEmail(string email)
        {
            var log = Log.ForContext("Email", email); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por email: {Email}.", email);

                var query = new GetClienteByEmailQuery { Email = email };
                var cliente = await _mediator.Send(query);

                log.Information("Cliente com email {Email} encontrado com sucesso.", email);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por email: {Email}.", email);
                return NotFound("cliente não encontrado.");
            }
        }

        [HttpGet("busca-cliente-por-cpf-cnpj/{cpfcnpj}")]
        public async Task<ActionResult<ClienteDTO>> GetByCpfCnpj(string cpfcnpj)
        {
            var log = Log.ForContext("CpfCnpj", cpfcnpj); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando cliente por CPF/CNPJ: {CpfCnpj}.", cpfcnpj);

                var query = new GetClienteByCPFCNPJQuery { CpfCnpj = cpfcnpj };
                var cliente = await _mediator.Send(query);

                log.Information("Cliente com CPF/CNPJ {CpfCnpj} encontrado com sucesso.", cpfcnpj);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar cliente por CPF/CNPJ: {CpfCnpj}.", cpfcnpj);
                return NotFound("cliente não encontrado.");
            }
        }

        [HttpGet("todos-clientes")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAll()
        {
            try
            {
                Log.Information("Buscando todos os clientes.");

                var query = new GetAllClientesQuery();
                var clientes = await _mediator.Send(query);

                Log.Information("Todos os clientes foram buscados com sucesso.");
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os clientes.");
                return StatusCode(500, "Erro interno ao buscar todos clientes.");
            }
        }

        [HttpGet("todos-clientes-de-uma-cidade/{cidade}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllByCidade(string cidade)
        {
            try
            {
                Log.Information("Buscando todos os clientes de uma cidade.");

                var query = new GetAllClientesByCidadeQuery { Cidade = cidade };
                var clientes = await _mediator.Send(query);

                Log.Information("Todos os clientes de uma cidade foram buscados com sucesso.");
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os clientes de uma cidade.");
                return StatusCode(500, "Erro interno ao buscar todos clientes de uma cidade.");
            }
        }

        [HttpGet("todos-clientes-de-uma-uf/{uf}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAllByUF(string uf)
        {
            try
            {
                Log.Information("Buscando todos os clientes de uma UF.");

                var query = new GetAllClientesByUFQuery { UF = uf};
                var clientes = await _mediator.Send(query);

                Log.Information("Todos os clientes de uma UF foram buscados com sucesso.");
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os clientes de uma UF.");
                return StatusCode(500, "Erro interno ao buscar todos clientes de uma UF.");
            }
        }

        [HttpGet("todos-clientes-por-tipo/{tipo}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetByTipo(string tipo)
        {
            var query = new GetClienteByTipoQuery { Tipo = tipo };
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        [HttpPost("cadastrar-cliente")]
        public async Task<ActionResult<int>> Create([FromBody] CreateClienteCommand command)
        {
            var log = Log.ForContext("Nome", command.Nome); // Adiciona contexto ao log

            try
            {
                log.Information("Cadastrando um novo Cliente com nome: {Nome}.", command.Nome);

                var clienteId = await _mediator.Send(command);

                log.Information("Cliente {Nome} criado com sucesso. ID: {clienteId}.", command.Nome, clienteId);
                return Ok(clienteId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar cliente com nome: {Nome}.", command.Nome);
                return BadRequest("Erro ao criar cliente.");
            }
        }

        [HttpPut("editar-cliente")]
        public async Task<ActionResult> Update([FromBody] UpdateClienteCommand command)
        {
            var log = Log.ForContext("clienteId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando cliente com ID: {clienteId}.", command.Id);

                await _mediator.Send(command);

                log.Information("Cliente {clienteId} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar cliente com ID: {clienteId}.", command.Id);
                return BadRequest("Erro ao atualizar cliente.");
            }
        }

        [HttpDelete("excluir-usuario/{id}")]
        [Authorize(Roles = "ADM,USR")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("clienteId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo cliente com ID: {clienteId}.", id);

                var command = new DeleteClienteCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Cliente {clienteId} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir cliente com ID: {clienteId}.", id);
                return BadRequest("Erro ao excluir cliente.");
            }
        }
    }
}
