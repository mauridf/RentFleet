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

namespace RentFleet.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra repositórios
            services.AddScoped<IUserRepository, UserRepository>();

            // Registra serviços de infraestrutura
            services.AddScoped<PasswordHasher>();
            services.AddScoped<JwtTokenGenerator>();

            // Registra MediatR
            services.AddMediatR(typeof(Program).Assembly);

            // Registra AutoMapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);

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

            return services;
        }
    }
}