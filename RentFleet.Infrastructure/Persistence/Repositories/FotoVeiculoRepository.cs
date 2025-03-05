using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class FotoVeiculoRepository : IFotoVeiculoRepository
    {
        private readonly RentFleetDbContext _context;

        public FotoVeiculoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FotoVeiculo foto)
        {
            await _context.FotosVeiculos.AddAsync(foto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foto = await _context.FotosVeiculos.FindAsync(id);
            if (foto != null)
            {
                _context.FotosVeiculos.Remove(foto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FotoVeiculo> GetByIdAsync(int id)
        {
            return await _context.FotosVeiculos.FindAsync(id);
        }

        public async Task<List<FotoVeiculo>> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.FotosVeiculos
                                 .Where(d => d.VeiculoId == veiculoId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(FotoVeiculo foto)
        {
            _context.FotosVeiculos.Update(foto);
            await _context.SaveChangesAsync();
        }
    }
}
