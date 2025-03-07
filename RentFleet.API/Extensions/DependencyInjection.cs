using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Repositories;
using RentFleet.Infrastructure.Security;
using MediatR;
using FluentValidation;
using RentFleet.Application.Handlers.User;
using RentFleet.Application.Commands;
using RentFleet.Application.Queries;
using RentFleet.Application.DTOs;
using RentFleet.Application.Mappings;
using RentFleet.Application.Mapping;
using RentFleet.Application.Handlers.Cliente;
using RentFleet.Application.Commands.Clientes;
using RentFleet.Application.Queries.Cliente;
using RentFleet.Application.Commands.Veiculo;
using RentFleet.Application.Handlers.Veiculo;
using RentFleet.Application.Queries.Veiculo;
using RentFleet.Application.Commands.DadosCaminhao;
using RentFleet.Application.Handlers.DadosCaminhao;
using RentFleet.Application.Queries.DadosCaminhao;
using RentFleet.Application.Commands.DadosMoto;
using RentFleet.Application.Handlers.DadosMoto;
using RentFleet.Application.Queries.DadosMoto;
using RentFleet.Application.Commands.DocumentoDigitalizado;
using RentFleet.Application.Handlers.DocumentoDigitalizado;
using RentFleet.Application.Queries.DocumentoDigitalizado;
using RentFleet.Application.Commands.FotoVeiculo;
using RentFleet.Application.Handlers.FotoVeiculo;
using RentFleet.Application.Queries.FotoVeiculo;
using RentFleet.Domain.Entities;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;
using RentFleet.Application.Handlers.DadosLocalizacaoOperacao;
using RentFleet.Application.Queries.DadosLocalizacaoOperacao;
using RentFleet.Application.Commands.DadosSegurancaConformidade;
using RentFleet.Application.Handlers.DadosSegurancaConformidade;
using RentFleet.Application.Queries.DadosSegurancaConformidade;

namespace RentFleet.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra repositórios
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IDadosCaminhaoRepository, DadosCaminhaoRepository>();
            services.AddScoped<IDadosMotoRepository, DadosMotoRepository>();
            services.AddScoped<IDocumentoDigitalizadoRepository, DocumentoDigitalizadoRepository>();
            services.AddScoped<IFotoVeiculoRepository, FotoVeiculoRepository>();
            services.AddScoped<IDadosLocalizacaoOperacaoRepository, DadosLocalizacaoOperacaoRepository>();
            services.AddScoped<IDadosSegurancaConformidadeRepository, DadosSegurancaConformidadeRepository>();

            // Registra serviços de infraestrutura
            services.AddScoped<PasswordHasher>();
            services.AddScoped<JwtTokenGenerator>();

            // Registra MediatR
            services.AddMediatR(typeof(Program).Assembly);

            // Registra AutoMapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddAutoMapper(typeof(ClienteProfile).Assembly);
            services.AddAutoMapper(typeof(VeiculoProfile).Assembly);
            services.AddAutoMapper(typeof(DadosCaminhaoProfile).Assembly);
            services.AddAutoMapper(typeof(DadosMotoProfile).Assembly);
            services.AddAutoMapper(typeof(DocumentoDigitalizadoProfile).Assembly);
            services.AddAutoMapper(typeof(FotoVeiculoProfile).Assembly);
            services.AddAutoMapper(typeof(DadosLocalizacaoOperacaoProfile).Assembly);
            services.AddAutoMapper(typeof(DadosSegurancaConformidadeProfile).Assembly);

            // Registra FluentValidation
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            // Registra Handlers
            services.AddTransient<IRequestHandler<CreateUserCommand, int>, CreateUserCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();
            services.AddTransient<IRequestHandler<GetUserByIdQuery, UserDTO>, GetUserByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetUserByNomeQuery, UserDTO>, GetUserByNomeQueryHandler>();
            services.AddTransient<IRequestHandler<GetUserByEmailQuery, UserDTO>, GetUserByEmailQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>, GetAllUsersQueryHandler>();

            services.AddTransient<IRequestHandler<LoginCommand, string>, LoginCommandHandler>();

            services.AddTransient<IRequestHandler<CreateClienteCommand, int>, CreateClienteCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateClienteCommand, Unit>, UpdateClienteCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteClienteCommand, Unit>, DeleteClienteCommandHandler>();
            services.AddTransient<IRequestHandler<GetClienteByIdQuery, ClienteDTO>, GetClienteByIdQueryHander>();
            services.AddTransient<IRequestHandler<GetClienteByNomeQuery, ClienteDTO>, GetClienteByNomeQueryHander>();
            services.AddTransient<IRequestHandler<GetClienteByEmailQuery, ClienteDTO>, GetClienteByEmailQueryHander>();
            services.AddTransient<IRequestHandler<GetClienteByCPFCNPJQuery, ClienteDTO>, GetClienteByCPFCNPJQueryHander>();
            services.AddTransient<IRequestHandler<GetAllClientesQuery, IEnumerable<ClienteDTO>>, GetAllClientesQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllClientesByCidadeQuery, IEnumerable<ClienteDTO>>, GetAllClientesByCidadeQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllClientesByUFQuery, IEnumerable<ClienteDTO>>, GetAllClientesByUFQueryHandler>();
            services.AddTransient<IRequestHandler<GetClienteByTipoQuery, IEnumerable<ClienteDTO>>, GetClienteByTipoQueryHandler>();

            services.AddTransient<IRequestHandler<CreateVeiculoCommand, int>, CreateVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateVeiculoCommand, Unit>, UpdateVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteVeiculoCommand, Unit>, DeleteVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<GetVeiculoByIdQuery, VeiculoDTO>, GetVeiculoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetVeiculoByPlacaQuery, VeiculoDTO>, GetVeiculoByPlacaQueryHandler>();
            services.AddTransient<IRequestHandler<GetVeiculoByChassiQuery, VeiculoDTO>, GetVeiculoByChassiQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosCategoriaQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosCategoriaQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByCombustivelQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosCombustivelQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByTipoQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByTipoQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByNumeroPortasQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByNumeroPortasQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByModeloQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByModeloQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByMarcaQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByMarcaQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByCorQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByCorQueryHandler>();
            services.AddTransient<IRequestHandler<GetAllVeiculosByAnoFabricacaoModeloQuery, IEnumerable<VeiculoDTO>>, GetAllVeiculosByAnoFabricacaoModeloQueryHandler>();

            services.AddTransient<IRequestHandler<CreateDadosCaminhaoCommand, int>, CreateDadosCaminhaoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateDadosCaminhaoCommand, Unit>, UpdateDadosCaminhaoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteDadosCaminhaoCommand, Unit>, DeleteDadosCaminhaoCommandHandler>();
            services.AddTransient<IRequestHandler<GetDadosCaminhaoByIdQuery, DadosCaminhaoDTO>, GetDadosCaminhaoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetDadosCaminhaoByVeiculoIdQuery, DadosCaminhaoDTO>, GetDadosCaminhaoByVeiculoIdQueryHandler>();

            services.AddTransient<IRequestHandler<CreateDadosMotoCommand, int>, CreateDadosMotoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateDadosMotoCommand, Unit>, UpdateDadosMotoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteDadosMotoCommand, Unit>, DeleteDadosMotoCommandHandler>();
            services.AddTransient<IRequestHandler<GetDadosMotoByIdQuery, DadosMotoDTO>, GetDadosMotoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetDadosMotoByVeiculoIdQuery, DadosMotoDTO>, GetDadosMotoByVeiculoIdQueryHandler>();

            services.AddTransient<IRequestHandler<CreateDocumentoDigitalizadoCommand, int>, CreateDocumentoDigitalizadoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateDocumentoDigitalizadoCommand, Unit>, UpdateDocumentoDigitalizadoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteDocumentoDigitalizadoCommand, Unit>, DeleteDocumentoDigitalizadoCommandHandler>();
            services.AddTransient<IRequestHandler<GetDocumentoDigitalizadoByIdQuery, DocumentoDigitalizadoDTO>, GetDocumentoDigitalizadoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetDocumentoDigitalizadoByVeiculoIdQuery, List<DocumentoDigitalizadoDTO>>, GetDocumentoDigitalizadoByVeiculoIdQueryHandler>();

            services.AddTransient<IRequestHandler<CreateFotoVeiculoCommand, int>, CreateFotoVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateFotoVeiculoCommand, Unit>, UpdateFotoVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteFotoVeiculoCommand, Unit>, DeleteFotoVeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<GetFotoVeiculoByIdQuery, FotoVeiculoDTO>, GetFotoVeiculoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetFotoVeiculoByVeiculoIdQuery, List<FotoVeiculoDTO>>, GetFotoVeiculoByVeiculoIdHandler>();

            services.AddTransient<IRequestHandler<CreateDadosLocalizacaoOperacaoCommand, int>, CreateDadosLocalizacaoOperacaoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateDadosLocalizacaoOperacaoCommand, Unit>, UpdateDadosLocalizacaoOperacaoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteDadosLocalizacaoOperacaoCommand, Unit>, DeleteDadosLocalizacaoOperacaoCommandHandler>();
            services.AddTransient<IRequestHandler<GetDadosLocalizacaoOperacaoByVeiculoIdQuery, DadosLocalizacaoOperacaoDTO>, GetDadosLocalizacaoOperacaoByVeiculoIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetDadosLocalizacaoOperacaoByIdQuery, DadosLocalizacaoOperacaoDTO>, GetDadosLocalizacaoOperacaoByIdQueryHandler>();

            services.AddTransient<IRequestHandler<CreateDadosSegurancaConformidadeCommand, int>, CreateDadosSegurancaConformidadeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateDadosSegurancaConformidadeCommand, Unit>, UpdateDadosSegurancaConformidadeCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteDadosSegurancaConformidadeCommand, Unit>, DeleteDadosSegurancaConformidadeCommandHandler>();
            services.AddTransient<IRequestHandler<GetDadosSegurancaConformidadeByVeiculoIdQuery, DadosSegurancaConformidadeDTO>, GetDadosSegurancaConformidadeByVeiculoIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetDadosSegurancaConformidadeByIdQuery, DadosSegurancaConformidadeDTO>, GetDadosSegurancaConformidadeByIdQueryHandler>();

            return services;
        }
    }
}