using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DadosTecnicosVeiculoRepository : IDadosTecnicosVeiculoRepository
    {
        private RentFleetDbContext _context;

        public DadosTecnicosVeiculoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DadosTecnicosVeiculo dadosTecnicos)
        {
            await _context.DadosTecnicosVeiculos.AddAsync(dadosTecnicos);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dadosTecnicos = await _context.DadosTecnicosVeiculos.FindAsync(id);
            if (dadosTecnicos != null)
            {
                _context.DadosTecnicosVeiculos.Remove(dadosTecnicos);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DadosTecnicosVeiculo> GetByIdAsync(int id)
        {
            return await _context.DadosTecnicosVeiculos.FindAsync(id);
        }

        public async Task<DadosTecnicosVeiculo> GetByVeiculoIdAsync(int veiculoId)
        {
            return await _context.DadosTecnicosVeiculos.FirstOrDefaultAsync(t => t.VeiculoId == veiculoId);
        }

        public async Task UpdateAsync(DadosTecnicosVeiculo dadosTecnicos)
        {
            _context.DadosTecnicosVeiculos.Update(dadosTecnicos);
            await _context.SaveChangesAsync();
        }
    }
}
