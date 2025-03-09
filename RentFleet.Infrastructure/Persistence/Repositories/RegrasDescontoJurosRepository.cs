using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class RegrasDescontoJurosRepository : IRegraDescontoJurosRepository
    {
        private readonly RentFleetDbContext _context;

        public RegrasDescontoJurosRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RegraDescontoJuros regras)
        {
            await _context.RegrasDescontoJuros.AddAsync(regras);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var regras = await _context.RegrasDescontoJuros.FindAsync(id);
            if (regras != null)
            {
                _context.RegrasDescontoJuros.Remove(regras);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RegraDescontoJuros>> GetAllByTipoRegraAsync(string tipo)
        {
            return await _context.RegrasDescontoJuros
                .Where(r => EF.Functions.Like(r.TipoRegra.ToString().ToUpper(), tipo.ToUpper()))
                .ToListAsync();
        }

        public async Task<RegraDescontoJuros> GetByIdAsync(int id)
        {
            return await _context.RegrasDescontoJuros.FindAsync(id);
        }

        public async Task UpdateAsync(RegraDescontoJuros regras)
        {
            _context.RegrasDescontoJuros.Update(regras);
            await _context.SaveChangesAsync();
        }
    }
}
