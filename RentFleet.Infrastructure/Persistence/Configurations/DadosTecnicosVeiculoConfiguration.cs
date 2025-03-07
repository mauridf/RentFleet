using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DadosTecnicosVeiculoConfiguration : IEntityTypeConfiguration<DadosTecnicosVeiculo>
    {
        public void Configure(EntityTypeBuilder<DadosTecnicosVeiculo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.VeiculoId).IsRequired();
            builder.Property(t => t.PotenciaMotor).IsRequired();
            builder.Property(t => t.Cilindrada).IsRequired();
            builder.Property(t => t.Transmissao).IsRequired();
            builder.Property(t => t.NumeroMarchas).IsRequired();
            builder.Property(t => t.Tracao).IsRequired();
            builder.Property(t => t.PesoBrutoTotal).IsRequired();
            builder.Property(t => t.CapacidadeCarga).IsRequired();
            builder.Property(t => t.NumeroEixos).IsRequired();
        }
    }
}
