using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DadosLocalizacaoOperacaoConfiguration : IEntityTypeConfiguration<DadosLocalizacaoOperacao>
    {
        public void Configure(EntityTypeBuilder<DadosLocalizacaoOperacao> builder)
        {
            builder.HasKey(dlo => dlo.Id);
            builder.Property(dlo => dlo.VeiculoId).IsRequired();
            builder.Property(dlo => dlo.FilialRegistro).HasMaxLength(200);
            builder.Property(dlo => dlo.StatusLocacao).IsRequired();
            builder.Property(dlo => dlo.DataAquisicao).IsRequired();
            builder.Property(dlo => dlo.ValorAquisicao).IsRequired();
            builder.Property(dlo => dlo.ValorLocacaoDiaria).IsRequired();
            builder.Property(dlo => dlo.Observacoes).HasMaxLength(500);
        }
    }
}
