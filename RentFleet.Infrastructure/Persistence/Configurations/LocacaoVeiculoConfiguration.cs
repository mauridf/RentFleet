using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class LocacaoVeiculoConfiguration : IEntityTypeConfiguration<LocacaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<LocacaoVeiculo> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.VeiculoId).IsRequired();
            builder.Property(l => l.ClienteId).IsRequired();
            builder.Property(l => l.DataInicio).IsRequired().HasColumnType("timestamp with time zone");
            builder.Property(l => l.DataFim).IsRequired().HasColumnType("timestamp with time zone");
            builder.Property(l => l.ValorBase).IsRequired();
            builder.Property(l => l.Juros).IsRequired();
            builder.Property(l => l.Desconto).IsRequired();
            builder.Property(l => l.ValorTotal).IsRequired();
            builder.Property(l => l.StatusLocacao).IsRequired();
            builder.Property(l => l.QuilometragemInicial).IsRequired();
            builder.Property(l => l.QuilometragemFinal).IsRequired(false); // Pode ser null
            builder.Property(l => l.DataDevolucao).IsRequired().HasColumnType("timestamp with time zone");
            builder.Property(l => l.Observacoes).IsRequired(false); // Pode ser null
        }
    }
}
