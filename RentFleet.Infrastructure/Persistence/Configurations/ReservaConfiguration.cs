using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentFleet.Domain.Entities;

namespace RentFleet.Infrastructure.Persistence.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.VeiculoId).IsRequired();
            builder.Property(r => r.ClienteId).IsRequired();
            builder.Property(r => r.DataReserva).IsRequired();
            builder.Property(r => r.DataInicio).IsRequired();
            builder.Property(r => r.DataFim).IsRequired();
            builder.Property(r => r.StatusReserva).IsRequired();
        }
    }
}
