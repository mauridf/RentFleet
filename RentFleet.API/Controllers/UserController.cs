using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var query = new GetUserByIdQuery { Id = id };
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet("busca-usuario-por-nome/{nome}")]
        public async Task<ActionResult<UserDTO>> GetByNome(string nome)
        {
            var query = new GetUserByNomeQuery { Nome = nome };
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet("busca-usuario-por-email/{email}")]
        public async Task<ActionResult<UserDTO>> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery { Email = email };
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet("buscar-todos")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost("cadastrar-novo-usuario")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPut("editar-usuario")]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("excluir-usuario/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}