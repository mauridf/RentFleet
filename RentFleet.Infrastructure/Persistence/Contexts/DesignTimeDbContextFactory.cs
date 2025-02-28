using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RentFleet.Infrastructure.Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentFleetDbContext>
    {
        public RentFleetDbContext CreateDbContext(string[] args)
        {
            // Configuração para ler o appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configura o DbContextOptions
            var builder = new DbContextOptionsBuilder<RentFleetDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);

            return new RentFleetDbContext(builder.Options);
        }
    }
}