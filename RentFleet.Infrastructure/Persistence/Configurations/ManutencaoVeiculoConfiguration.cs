using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class ManutencaoVeiculoConfiguration : IEntityTypeConfiguration<ManutencaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<ManutencaoVeiculo> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.VeiculoId).IsRequired();
            builder.Property(m => m.DataManutencao).IsRequired();
            builder.Property(m => m.TipoManutencao).IsRequired();
            builder.Property(m => m.Descricao).HasMaxLength(500);
            builder.Property(m => m.Custo).IsRequired();
            builder.Property(m => m.Quilometragem).IsRequired();
        }
    }
}
