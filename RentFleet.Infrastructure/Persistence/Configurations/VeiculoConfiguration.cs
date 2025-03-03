using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Tipo).IsRequired();
            builder.Property(c => c.Categoria).IsRequired();
            builder.Property(c => c.Marca).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Modelo).IsRequired().HasMaxLength(100);
            builder.Property(c => c.AnoFabricacao).IsRequired();
            builder.Property(c => c.AnoModelo).IsRequired();
            builder.Property(c => c.Cor).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Placa).IsRequired().HasMaxLength(8);
            builder.Property(c => c.Chassi).IsRequired().HasMaxLength(17);
            builder.Property(c => c.QuilometragemInicial).IsRequired();
            builder.Property(c => c.QuilometragemAtual).IsRequired();
            builder.Property(c => c.NumeroPortas).IsRequired();
            builder.Property(c => c.CapacidadeTanque).IsRequired();
            builder.Property(c => c.Combustivel).IsRequired();
        }
    }
}
