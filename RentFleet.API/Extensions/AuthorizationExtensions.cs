using Microsoft.AspNetCore.Authorization;

namespace RentFleet.API.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy("AdminOnly", policy => policy.RequireRole("ADM"))
                .AddPolicy("UserOnly", policy => policy.RequireRole("USR"));

            return services;
        }
    }
}