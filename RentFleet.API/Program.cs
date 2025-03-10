using Microsoft.EntityFrameworkCore;
using RentFleet.Infrastructure.Logs;
using RentFleet.Infrastructure.Persistence.Contexts;
using RentFleet.API.Extensions; // Importa as classes de extens�o
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<RentFleetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Registra todos os servi�os, reposit�rios, handlers, etc.
builder.Services.AddApplicationServices();

// Configura��o do JWT e Autentica��o
builder.Services.AddJwtAuthentication(builder.Configuration);

// Configura��o da Autoriza��o
builder.Services.AddCustomAuthorization();

// Configura��o do Swagger
builder.Services.AddCustomSwagger();

// Configura��o do Serilog
SerilogConfig.Configure();
builder.Host.UseSerilog();

// Adiciona suporte a controllers da API
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();