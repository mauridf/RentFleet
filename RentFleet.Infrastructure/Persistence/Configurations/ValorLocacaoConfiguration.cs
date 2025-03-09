using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class ValorLocacaoConfiguration : IEntityTypeConfiguration<ValorLocacao>
    {
        public void Configure(EntityTypeBuilder<ValorLocacao> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.TipoVeiculo).IsRequired();
            builder.Property(v => v.Categoria).IsRequired();
            builder.Property(v => v.ValorDiaria).IsRequired();
        }
    }
}
