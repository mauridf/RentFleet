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

namespace RentFleet.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra repositórios
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            // Registra serviços de infraestrutura
            services.AddScoped<PasswordHasher>();
            services.AddScoped<JwtTokenGenerator>();

            // Registra MediatR
            services.AddMediatR(typeof(Program).Assembly);

            // Registra AutoMapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddAutoMapper(typeof(ClienteProfile).Assembly);

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

            return services;
        }
    }
}