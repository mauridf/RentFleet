using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class ValorLocacaoRepository : IValorLocacaoRepository
    {
        public RentFleetDbContext _context;

        public ValorLocacaoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ValorLocacao valor)
        {
            await _context.ValoresLocacao.AddAsync(valor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var valor = await _context.ValoresLocacao.FindAsync(id);
            if (valor != null)
            {
                _context.ValoresLocacao.Remove(valor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ValorLocacao>> GetAllByTipoVeiculoAsync(string tipo)
        {
            return await _context.ValoresLocacao
                .Where(v => EF.Functions.Like(v.TipoVeiculo.ToString().ToUpper(), tipo.ToUpper()))
                .ToListAsync();
        }

        public async Task<ValorLocacao?> GetByTipoCategoriaAsync(TipoVeiculo tipo, CategoriaVeiculo categoria)
        {
            return await _context.ValoresLocacao
                .FirstOrDefaultAsync(v => v.TipoVeiculo == tipo && v.Categoria == categoria);
        }

        public async Task<ValorLocacao> GetByIdAsync(int id)
        {
            return await _context.ValoresLocacao.FindAsync(id);
        }

        public async Task UpdateAsync(ValorLocacao valor)
        {
            _context.ValoresLocacao.Update(valor);
            await _context.SaveChangesAsync();
        }
    }
}
