using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DadosMotoConfiguration : IEntityTypeConfiguration<DadosMoto>
    {
        public void Configure(EntityTypeBuilder<DadosMoto> builder)
        {
            builder.HasKey(dm => dm.Id);
            builder.Property(dm => dm.VeiculoId).IsRequired();
            builder.Property(dm => dm.TipoMoto).IsRequired();
            builder.Property(dm => dm.CapacidadeBagageiro).IsRequired();
        }
    }
}
