using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Telefone).HasMaxLength(20);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CpfCnpj).IsRequired().HasMaxLength(14);
            builder.Property(c => c.Tipo).IsRequired().HasMaxLength(2);
            builder.Property(c => c.Endereco).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(c => c.UF).IsRequired().HasMaxLength(2);
            builder.Property(c => c.DataCadastro).IsRequired();
            builder.Property(c => c.DataAlteracao).IsRequired();

            // Índice único para Email
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
