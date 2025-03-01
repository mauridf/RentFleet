using Microsoft.AspNetCore.Mvc;
using MediatR;
using Serilog;
using RentFleet.Application.Commands;
using RentFleet.Application.Queries;
using RentFleet.Application.DTOs;

namespace RentFleet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("busca-usuario-por-id/{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var log = Log.ForContext("UserId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por ID: {UserId}.", id);

                var query = new GetUserByIdQuery { Id = id };
                var user = await _mediator.Send(query);

                log.Information("Usuário {UserId} encontrado com sucesso.", id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por ID: {UserId}.", id);
                return NotFound("Usuário não encontrado.");
            }
        }

        [HttpGet("busca-usuario-por-nome/{nome}")]
        public async Task<ActionResult<UserDTO>> GetByNome(string nome)
        {
            var log = Log.ForContext("Nome", nome); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por nome: {Nome}.", nome);

                var query = new GetUserByNomeQuery { Nome = nome };
                var user = await _mediator.Send(query);

                log.Information("Usuário com nome {Nome} encontrado com sucesso.", nome);
                return Ok(user);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por nome: {Nome}.", nome);
                return NotFound("Usuário não encontrado.");
            }
        }

        [HttpGet("busca-usuario-por-email/{email}")]
        public async Task<ActionResult<UserDTO>> GetByEmail(string email)
        {
            var log = Log.ForContext("Email", email); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por email: {Email}.", email);

                var query = new GetUserByEmailQuery { Email = email };
                var user = await _mediator.Send(query);

                log.Information("Usuário com email {Email} encontrado com sucesso.", email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por email: {Email}.", email);
                return NotFound("Usuário não encontrado.");
            }
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                Log.Information("Buscando todos os usuários.");

                var query = new GetAllUsersQuery();
                var users = await _mediator.Send(query);

                Log.Information("Todos os usuários foram buscados com sucesso.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao buscar todos os usuários.");
                return StatusCode(500, "Erro interno ao buscar usuários.");
            }
        }

        [HttpPost("cadastrar-novo-usuario")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
        {
            var log = Log.ForContext("Email", command.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Criando novo usuário com email: {Email}.", command.Email);

                var userId = await _mediator.Send(command);

                log.Information("Usuário {Email} criado com sucesso. ID: {UserId}.", command.Email, userId);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao criar usuário com email: {Email}.", command.Email);
                return BadRequest("Erro ao criar usuário.");
            }
        }

        [HttpPut("editar-usuario")]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var log = Log.ForContext("UserId", command.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Atualizando usuário com ID: {UserId}.", command.Id);

                await _mediator.Send(command);

                log.Information("Usuário {UserId} atualizado com sucesso.", command.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao atualizar usuário com ID: {UserId}.", command.Id);
                return BadRequest("Erro ao atualizar usuário.");
            }
        }

        [HttpDelete("excluir-usuario/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var log = Log.ForContext("UserId", id); // Adiciona contexto ao log

            try
            {
                log.Information("Excluindo usuário com ID: {UserId}.", id);

                var command = new DeleteUserCommand { Id = id };
                await _mediator.Send(command);

                log.Information("Usuário {UserId} excluído com sucesso.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao excluir usuário com ID: {UserId}.", id);
                return BadRequest("Erro ao excluir usuário.");
            }
        }
    }
}