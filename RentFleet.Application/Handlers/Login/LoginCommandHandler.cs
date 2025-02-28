using MediatR;
using Microsoft.Extensions.Logging;
using RentFleet.Application.Commands;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Security;
using Serilog;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher _passwordHasher;
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        IUserRepository userRepository,
        PasswordHasher passwordHasher,
        JwtTokenGenerator jwtTokenGenerator,
        ILogger<LoginCommandHandler> logger)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var log = Log.ForContext("Email", request.Email); // Adiciona contexto ao log

        try
        {
            log.Information("Iniciando autenticação para o email {Email}.", request.Email);

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                log.Warning("Usuário com email {Email} não encontrado.", request.Email);
                throw new Exception("Credenciais inválidas.");
            }

            log.Information("Usuário {Email} encontrado. Verificando senha.", request.Email);

            if (!_passwordHasher.VerifyPassword(user.Senha, request.Senha))
            {
                log.Warning("Senha inválida para o usuário {Email}.", request.Email);
                throw new Exception("Credenciais inválidas.");
            }

            log.Information("Usuário {Email} autenticado com sucesso. Gerando token JWT.", request.Email);

            var token = _jwtTokenGenerator.GenerateToken(user);

            log.Information("Token JWT gerado para o usuário {Email}.", request.Email);

            return token;
        }
        catch (Exception ex)
        {
            log.Error(ex, "Erro ao autenticar o usuário {Email}.", request.Email);
            throw; // Re-lança a exceção para ser tratada no Controller
        }
    }
}