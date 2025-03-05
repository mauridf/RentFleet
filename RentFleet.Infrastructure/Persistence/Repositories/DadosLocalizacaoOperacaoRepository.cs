using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DadosLocalizacaoOperacaoRepository : IDadosLocalizacaoOperacaoRepository
    {
        private readonly RentFleetDbContext _context;

        public DadosLocalizacaoOperacaoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DadosLocalizacaoOperacao dadosLocOper)
        {
            await _context.DadosLocalizacaoOperacoes.AddAsync(dadosLocOper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dadosLocOper = await _context.DadosLocalizacaoOperacoes.FindAsync(id);
            if (dadosLocOper != null)
            {
                _context.DadosLocalizacaoOperacoes.Remove(dadosLocOper);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DadosLocalizacaoOperacao> GetByIdAsync(int id)
        {
            return await _context.DadosLocalizacaoOperacoes.FindAsync(id);
        }

        public async Task UpdateAsync(DadosLocalizacaoOperacao dadosLocOper)
        {
            _context.DadosLocalizacaoOperacoes.Update(dadosLocOper);
            await _context.SaveChangesAsync();
        }
    }
}
