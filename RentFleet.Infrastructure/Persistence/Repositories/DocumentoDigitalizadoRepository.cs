using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;
using System.Numerics;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DocumentoDigitalizadoRepository : IDocumentoDigitalizadoRepository
    {

        private readonly RentFleetDbContext _context;

        public DocumentoDigitalizadoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DocumentoDigitalizado documento)
        {
            await _context.DocumentosDigitalizados.AddAsync(documento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var documento = await _context.DocumentosDigitalizados.FindAsync(id);
            if (documento != null)
            {
                _context.DocumentosDigitalizados.Remove(documento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DocumentoDigitalizado> GetByIdAsync(int id)
        {
            return await _context.DocumentosDigitalizados.FindAsync(id);
        }

        public async Task<List<DocumentoDigitalizado>> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.DocumentosDigitalizados
                                 .Where(d => d.VeiculoId == veiculoId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(DocumentoDigitalizado documento)
        {
            _context.DocumentosDigitalizados.Update(documento);
            await _context.SaveChangesAsync();
        }
    }
}
