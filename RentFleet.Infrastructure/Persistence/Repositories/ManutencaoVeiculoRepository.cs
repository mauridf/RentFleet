using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class ManutencaoVeiculoRepository : IManutencaoVeiculoRepository
    {
        private readonly RentFleetDbContext _context;

        public ManutencaoVeiculoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ManutencaoVeiculo manutencao)
        {
            await _context.ManutencoesVeiculos.AddAsync(manutencao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manutencao = await _context.ManutencoesVeiculos.FindAsync(id);
            if (manutencao != null)
            {
                _context.ManutencoesVeiculos.Remove(manutencao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ManutencaoVeiculo>> GetAllByTipoManutencaoAsync(string tipo)
        {
            return await _context.ManutencoesVeiculos
                .Where(m => EF.Functions.Like(m.TipoManutencao.ToString().ToUpper(), tipo.ToUpper()))
                .ToListAsync();
        }

        public async Task<IEnumerable<ManutencaoVeiculo>> GetAllByVeiculoIdAsync(int veiculoId)
        {
            return await _context.ManutencoesVeiculos
                .Where(m => m.VeiculoId == veiculoId)
                .ToListAsync();
        }

        public async Task<ManutencaoVeiculo> GetByIdAsync(int id)
        {
            return await _context.ManutencoesVeiculos.FindAsync(id);
        }

        public async Task UpdateAsync(ManutencaoVeiculo manutencao)
        {
            _context.ManutencoesVeiculos.Update(manutencao);
            await _context.SaveChangesAsync();
        }
    }
}
