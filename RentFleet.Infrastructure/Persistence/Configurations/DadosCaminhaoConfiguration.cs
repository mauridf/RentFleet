using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DadosCaminhaoConfiguration : IEntityTypeConfiguration<DadosCaminhao>
    {
        public void Configure(EntityTypeBuilder<DadosCaminhao> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.Property(dc => dc.VeiculoId).IsRequired();
            builder.Property(dc => dc.TipoCaminhao).IsRequired();
            builder.Property(dc => dc.ComprimentoCarroceria).IsRequired();
            builder.Property(dc => dc.AlturaCarroceria).IsRequired();
            builder.Property(dc => dc.LarguraCarroceria).IsRequired();
            builder.Property(dc => dc.TipoCarroceria).IsRequired();
        }
    }
}
