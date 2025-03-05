using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class DocumentoDigitalizadoConfiguration : IEntityTypeConfiguration<DocumentoDigitalizado>
    {
        public void Configure(EntityTypeBuilder<DocumentoDigitalizado> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.VeiculoId).IsRequired();
            builder.Property(d => d.Descricao).HasMaxLength(500);
            builder.Property(d => d.UrlDocumento).IsRequired().HasMaxLength(200);
        }
    }
}
