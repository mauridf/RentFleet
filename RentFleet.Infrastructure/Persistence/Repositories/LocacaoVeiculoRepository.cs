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

        public async Task<Dictionary<TipoVeiculo, int>> GetVeiculosMaisLocadosPorTipo()
        {
            return await _context.LocacoesVeiculos
                .GroupBy(l => l.Veiculo.Tipo)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Tipo, x => x.Count);
        }

        public async Task<List<LocacaoVeiculo>> GetLocacoesPorMes(int ano, int mes)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.DataInicio.Year == ano && l.DataInicio.Month == mes)
                .ToListAsync();
        }

        public async Task<decimal> GetValorTotalLocacoesPorMes(int ano, int mes)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.DataInicio.Year == ano && l.DataInicio.Month == mes)
                .SumAsync(l => l.ValorTotal);
        }

        public async Task<Dictionary<TipoVeiculo, decimal>> GetValorTotalLocacoesPorMesPorTipo(int ano, int mes)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.DataInicio.Year == ano && l.DataInicio.Month == mes)
                .GroupBy(l => l.Veiculo.Tipo)
                .Select(g => new { Tipo = g.Key, Total = g.Sum(l => l.ValorTotal) })
                .ToDictionaryAsync(x => x.Tipo, x => x.Total);
        }

        public async Task<int> GetTotalVeiculos()
        {
            return await _context.Veiculos.CountAsync();
        }

        public async Task<int> GetVeiculosAtualmenteAlugados()
        {
            return await _context.LocacoesVeiculos
                .CountAsync(l => l.StatusLocacao == RentFleet.Domain.Enums.StatusLocacao.Ativa);
        }

        public async Task<double> GetMediaDiasLocacao()
        {
            var locacoes = await _context.LocacoesVeiculos
                .Where(l => l.StatusLocacao == RentFleet.Domain.Enums.StatusLocacao.Finalizada)
                .AsNoTracking()
                .ToListAsync(); // 🔹 Traz os dados para memória

            if (!locacoes.Any()) return 0;

            return locacoes.Average(l => (l.DataDevolucao ?? l.DataFim).Subtract(l.DataInicio).TotalDays);
        }

        public async Task<int> GetClienteComMaisLocacoes()
        {
            return await _context.LocacoesVeiculos
                .GroupBy(l => l.ClienteId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> GetFaturamentoAnual(int ano)
        {
            return await _context.LocacoesVeiculos
                .Where(l => l.DataInicio.Year == ano)
                .SumAsync(l => l.ValorTotal);
        }

        public async Task<int> GetQuantidadeLocacoesPorMes(int ano, int mes)
        {
            return await _context.LocacoesVeiculos
                .CountAsync(l => l.DataInicio.Year == ano && l.DataInicio.Month == mes);
        }

        public async Task<List<LocacaoVeiculo>> GetVeiculosLocados()
        {
            return await _context.LocacoesVeiculos
                .Include(l => l.Veiculo)
                .Where(l => l.StatusLocacao == StatusLocacao.Ativa)
                .ToListAsync();
        }

        public async Task<List<LocacaoVeiculo>> GetVeiculosDisponiveis()
        {
            return await _context.LocacoesVeiculos
                .Include(l => l.Veiculo)
                .Where(l => l.StatusLocacao == StatusLocacao.Finalizada)
                .ToListAsync();
        }
    }
}
