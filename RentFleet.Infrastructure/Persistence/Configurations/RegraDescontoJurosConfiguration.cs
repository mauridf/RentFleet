using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class RegraDescontoJurosConfiguration : IEntityTypeConfiguration<RegraDescontoJuros>
    {
        public void Configure(EntityTypeBuilder<RegraDescontoJuros> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.TipoVeiculo).IsRequired();
            builder.Property(r => r.Categoria).IsRequired();
            builder.Property(r => r.TipoRegra).IsRequired();
            builder.Property(r => r.Percentual).IsRequired();
            builder.Property(r => r.Descricao).IsRequired();
        }
    }
}
