using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentFleet.Application.Commands;
using RentFleet.Domain.Entities;
using Serilog;

namespace RentFleet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginCommand command)
        {
            var log = Log.ForContext("Email", command.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Tentativa de login para o email {Email}.", command.Email);

                var token = await _mediator.Send(command);

                log.Information("Usuário {Email} autenticado com sucesso.", command.Email);
                return Ok(token);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Falha ao autenticar o usuário {Email}.", command.Email);
                return BadRequest("Credenciais inválidas.");
            }
        }
    }
}