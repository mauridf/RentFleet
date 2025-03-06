using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DadosSegurancaConformidadeRepository : IDadosSegurancaConformidadeRepository
    {
        private readonly RentFleetDbContext _context;

        public DadosSegurancaConformidadeRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DadosSegurancaConformidade segurancaConformidade)
        {
            await _context.DadosSegurancaConformidades.AddAsync(segurancaConformidade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var segurancaConformidade = await _context.DadosSegurancaConformidades.FindAsync(id);
            if (segurancaConformidade != null)
            {
                _context.DadosSegurancaConformidades.Remove(segurancaConformidade);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DadosSegurancaConformidade> GetByIdAsync(int id)
        {
            return await _context.DadosSegurancaConformidades.FindAsync(id);
        }

        public async Task<DadosSegurancaConformidade> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.DadosSegurancaConformidades
                .FirstOrDefaultAsync(d => d.VeiculoId == veiculoId);
        }


        public async Task UpdateAsync(DadosSegurancaConformidade segurancaConformidade)
        {
            _context.DadosSegurancaConformidades.Update(segurancaConformidade);
            await _context.SaveChangesAsync();
        }
    }
}
