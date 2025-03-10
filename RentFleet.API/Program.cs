using Microsoft.EntityFrameworkCore;
using RentFleet.Infrastructure.Logs;
using RentFleet.Infrastructure.Persistence.Contexts;
using RentFleet.API.Extensions; // Importa as classes de extensão
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<RentFleetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Registra todos os serviços, repositórios, handlers, etc.
builder.Services.AddApplicationServices();

// Configuração do JWT e Autenticação
builder.Services.AddJwtAuthentication(builder.Configuration);

// Configuração da Autorização
builder.Services.AddCustomAuthorization();

// Configuração do Swagger
builder.Services.AddCustomSwagger();

// Configuração do Serilog
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

// Configuração do pipeline de requisições HTTP
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