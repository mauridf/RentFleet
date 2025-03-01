using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly RentFleetDbContext _context;

        public ClienteRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllByCidadeAsync(string cidade)
        {
            return await _context.Clientes
                .Where(c => EF.Functions.Like(c.Cidade, cidade))
                .ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllByUFAsync(string uf)
        {
            return await _context.Clientes
                .Where(c => c.UF.ToUpper() == uf.ToUpper())
                .ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllByTipoAsync(string tipo)
        {
            return await _context.Clientes
                .Where(c => c.Tipo.ToUpper() == tipo.ToUpper())
                .ToListAsync();
        }

        public async Task<Cliente> GetByCPFCNPJAsync(string cpfcnpj)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.CpfCnpj == cpfcnpj);
        }

        public async Task<Cliente> GetByEmailAsync(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> GetByNomeAsync(string nome)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
