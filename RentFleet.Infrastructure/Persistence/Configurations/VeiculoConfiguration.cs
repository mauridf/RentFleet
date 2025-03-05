using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Tipo).IsRequired();
            builder.Property(v => v.Categoria).IsRequired();
            builder.Property(v => v.Marca).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Modelo).IsRequired().HasMaxLength(100);
            builder.Property(v => v.AnoFabricacao).IsRequired();
            builder.Property(v => v.AnoModelo).IsRequired();
            builder.Property(v => v.Cor).IsRequired().HasMaxLength(50);
            builder.Property(v => v.Placa).IsRequired().HasMaxLength(8);
            builder.Property(v => v.Chassi).IsRequired().HasMaxLength(17);
            builder.Property(v => v.QuilometragemInicial).IsRequired();
            builder.Property(v => v.QuilometragemAtual).IsRequired();
            builder.Property(v => v.NumeroPortas).IsRequired();
            builder.Property(v => v.CapacidadeTanque).IsRequired();
            builder.Property(v => v.Combustivel).IsRequired();
        }
    }
}
