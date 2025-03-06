using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DadosSegurancaConformidadeConfiguration : IEntityTypeConfiguration<DadosSegurancaConformidade>
    {
        public void Configure(EntityTypeBuilder<DadosSegurancaConformidade> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.VeiculoId).IsRequired();
            builder.Property(sc => sc.DataUltimaInspecao).IsRequired();
            builder.Property(sc => sc.StatusInspecao).IsRequired();
            builder.Property(sc => sc.NumeroSeguro).HasMaxLength(50).IsRequired();
            builder.Property(sc => sc.Seguradora).HasMaxLength(100).IsRequired();
            builder.Property(sc => sc.ValidadeSeguro).IsRequired();
            builder.Property(sc => sc.DataUltimaManutencao).IsRequired();
            builder.Property(sc => sc.ProximaManutencao).IsRequired();
            builder.Property(sc => sc.StatusVeiculo).IsRequired();
        }
    }
}
