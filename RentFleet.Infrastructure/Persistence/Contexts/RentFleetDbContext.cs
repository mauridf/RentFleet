using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Infrastructure.Persistence.Configurations;

namespace RentFleet.Infrastructure.Persistence.Contexts
{
    public class RentFleetDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<DadosTecnicosVeiculo> DadosTecnicosVeiculos { get; set; }
        public DbSet<DadosSegurancaConformidade> DadosSegurancaConformidades { get; set; }
        public DbSet<DadosLocalizacaoOperacao> DadosLocalizacaoOperacoes { get; set; }
        public DbSet<DadosMoto> DadosMotos { get; set; }
        public DbSet<DadosCaminhao> DadosCaminhoes { get; set; }
        public DbSet<FotoVeiculo> FotosVeiculos { get; set; }
        public DbSet<DocumentoDigitalizado> DocumentosDigitalizados { get; set; }
        public DbSet<ManutencaoVeiculo> ManutencoesVeiculos { get; set; }
        public DbSet<LocacaoVeiculo> LocacoesVeiculos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ValorLocacao> ValoresLocacao { get; set; }
        public DbSet<RegraDescontoJuros> RegrasDescontoJuros { get; set; }

        public RentFleetDbContext(DbContextOptions<RentFleetDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações das entidades
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());

            // Relacionamentos
            modelBuilder.Entity<DadosTecnicosVeiculo>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<DadosSegurancaConformidade>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<DadosLocalizacaoOperacao>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<DadosMoto>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<DadosCaminhao>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<FotoVeiculo>()
                .HasOne(f => f.Veiculo)
                .WithMany()
                .HasForeignKey(f => f.VeiculoId);

            modelBuilder.Entity<DocumentoDigitalizado>()
                .HasOne(d => d.Veiculo)
                .WithMany()
                .HasForeignKey(d => d.VeiculoId);

            modelBuilder.Entity<ManutencaoVeiculo>()
                .HasOne(m => m.Veiculo)
                .WithMany()
                .HasForeignKey(m => m.VeiculoId);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(l => l.Veiculo)
                .WithMany()
                .HasForeignKey(l => l.VeiculoId);

            modelBuilder.Entity<LocacaoVeiculo>()
                .HasOne(l => l.Cliente)
                .WithMany()
                .HasForeignKey(l => l.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Veiculo)
                .WithMany()
                .HasForeignKey(r => r.VeiculoId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteId);

            // Configuração para Enums como strings
            modelBuilder.Entity<ValorLocacao>()
                .Property(v => v.TipoVeiculo)
                .HasConversion<string>();

            modelBuilder.Entity<ValorLocacao>()
                .Property(v => v.Categoria)
                .HasConversion<string>();

            modelBuilder.Entity<RegraDescontoJuros>()
                .Property(r => r.TipoVeiculo)
                .HasConversion<string>();

            modelBuilder.Entity<RegraDescontoJuros>()
                .Property(r => r.Categoria)
                .HasConversion<string>();

            modelBuilder.Entity<RegraDescontoJuros>()
                .Property(r => r.TipoRegra)
                .HasConversion<string>();

            modelBuilder.Entity<Reserva>()
                .Property(r => r.StatusReserva)
                .HasConversion<string>();

            modelBuilder.Entity<LocacaoVeiculo>()
                .Property(l => l.StatusLocacao)
                .HasConversion<string>();

            modelBuilder.Entity<ManutencaoVeiculo>()
                .Property(m => m.TipoManutencao)
                .HasConversion<string>();

            modelBuilder.Entity<DadosCaminhao>()
                .Property(c => c.TipoCaminhao)
                .HasConversion<string>();

            modelBuilder.Entity<DadosCaminhao>()
                .Property(c => c.TipoCarroceria)
                .HasConversion<string>();

            modelBuilder.Entity<DadosMoto>()
                .Property(m => m.TipoMoto)
                .HasConversion<string>();

            modelBuilder.Entity<DadosLocalizacaoOperacao>()
                .Property(lo => lo.StatusLocacao)
                .HasConversion<string>();

            modelBuilder.Entity<DadosSegurancaConformidade>()
                .Property(sc => sc.StatusInspecao)
                .HasConversion<string>();

            modelBuilder.Entity<DadosSegurancaConformidade>()
                .Property(sc => sc.StatusVeiculo)
                .HasConversion<string>();

            modelBuilder.Entity<DadosTecnicosVeiculo>()
                .Property(t => t.Transmissao)
                .HasConversion<string>();

            modelBuilder.Entity<DadosTecnicosVeiculo>()
                .Property(t => t.Tracao)
                .HasConversion<string>();

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Tipo)
                .HasConversion<string>();

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Categoria)
                .HasConversion<string>();

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Combustivel)
                .HasConversion<string>();

            // Índices Únicos
            modelBuilder.Entity<Veiculo>()
                .HasIndex(v => v.Placa)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CpfCnpj)
                .IsUnique();

            // Propriedades Obrigatórias
            modelBuilder.Entity<User>()
                .Property(u => u.NomeAtendente)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .IsRequired();
        }
    }
}