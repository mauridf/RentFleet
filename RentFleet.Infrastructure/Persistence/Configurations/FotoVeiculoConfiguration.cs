using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class FotoVeiculoConfiguration : IEntityTypeConfiguration<FotoVeiculo>
    {
        public void Configure(EntityTypeBuilder<FotoVeiculo> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.VeiculoId).IsRequired();
            builder.Property(f => f.UrlImagem).IsRequired().HasMaxLength(200);
        }
    }
}
