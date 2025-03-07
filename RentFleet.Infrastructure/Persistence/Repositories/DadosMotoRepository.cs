using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DadosMotoRepository : IDadosMotoRepository
    {
        private readonly RentFleetDbContext _context;

        public DadosMotoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DadosMoto dadosMoto)
        {
            await _context.DadosMotos.AddAsync(dadosMoto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dadosMoto = await _context.DadosMotos.FindAsync(id);
            if (dadosMoto != null)
            {
                _context.DadosMotos.Remove(dadosMoto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DadosMoto> GetByIdAsync(int id)
        {
            return await _context.DadosMotos.FindAsync(id);
        }

        public async Task<DadosMoto> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.DadosMotos.FirstOrDefaultAsync(m => m.VeiculoId == veiculoId);
        }

        public async Task UpdateAsync(DadosMoto dadosMoto)
        {
            _context.DadosMotos.Update(dadosMoto);
            await _context.SaveChangesAsync();
        }
    }
}
