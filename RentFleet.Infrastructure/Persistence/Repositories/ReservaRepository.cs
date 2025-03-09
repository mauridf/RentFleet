using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;
using System.Drawing;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly RentFleetDbContext _context;

        public ReservaRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reserva>> GetAllByClienteIdAsync(int clienteId)
        {
            return await _context.Reservas
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> GetAllByVeiculoIdAsync(int veiculoId)
        {
            return await _context.Reservas
                .Where(r => r.VeiculoId == veiculoId)
                .ToListAsync();
        }

        public async Task<Reserva> GetByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }
    }
}
