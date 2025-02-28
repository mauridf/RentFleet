using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Logs;
using RentFleet.Infrastructure.Persistence.Contexts;
using RentFleet.Infrastructure.Persistence.Repositories;
using RentFleet.Infrastructure.Security;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<RentFleetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o PasswordHasher
builder.Services.AddScoped<PasswordHasher>();

// Registra o reposit�rio de usu�rios
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Configura��o do MediatR e AutoMapper
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Configura��o do JWT
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret))
    };
});

// Configura��o do Serilog
SerilogConfig.Configure();
builder.Host.UseSerilog();

// Adiciona suporte a controllers da API
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
// Configura��o do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentFleet API", Version = "v1" });
});

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();