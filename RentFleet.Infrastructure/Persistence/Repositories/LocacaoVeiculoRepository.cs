using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class LocacaoVeiculoRepository : ILocacaoVeiculoRepository
    {
        private readonly RentFleetDbContext _context;

        public LocacaoVeiculoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LocacaoVeiculo locacao)
        {
            await _context.LocacoesVeiculos.AddAsync(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var locacao = await _context.LocacoesVeiculos.FindAsync(id);
            if (locacao != null)
            {
                _context.LocacoesVeiculos.Remove(locacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LocacaoVeiculo>> GetAllByClienteIdAsync(int clienteId)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LocacaoVeiculo>> GetAllByVeiculoIdAsync(int veiculoId)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.VeiculoId == veiculoId)
                .ToListAsync();
        }

        public async Task<LocacaoVeiculo?> GetUltimaLocacaoPorVeiculo(int veiculoId)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.VeiculoId == veiculoId)
                .OrderByDescending(l => l.DataInicio)
                .FirstOrDefaultAsync();
        }

        public async Task<LocacaoVeiculo?> GetLocacaoAtivaPorVeiculo(int veiculoId)
        {
            return await _context.LocacoesVeiculos
                .FirstOrDefaultAsync(l => l.VeiculoId == veiculoId && l.StatusLocacao == StatusLocacao.Ativa);
        }

        public async Task<LocacaoVeiculo> GetByIdAsync(int id)
        {
            return await _context.LocacoesVeiculos.FindAsync(id);
        }

        public async Task UpdateAsync(LocacaoVeiculo locacao)
        {
            _context.LocacoesVeiculos.Update(locacao);
            await _context.SaveChangesAsync();
        }
    }
}
