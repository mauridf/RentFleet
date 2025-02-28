using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.NomeAtendente).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Telefone).HasMaxLength(20);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Tipo).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Ativo).IsRequired();
            builder.Property(u => u.DataCadastro).IsRequired();
            builder.Property(u => u.DataAlteracao).IsRequired();

            // Índice único para Email
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
