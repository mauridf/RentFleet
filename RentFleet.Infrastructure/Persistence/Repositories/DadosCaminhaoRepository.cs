using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class DadosCaminhaoRepository : IDadosCaminhaoRepository
    {
        private readonly RentFleetDbContext _context;

        public DadosCaminhaoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DadosCaminhao dadosCaminhao)
        {
            await _context.DadosCaminhoes.AddAsync(dadosCaminhao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dadosCaminhao = await _context.DadosCaminhoes.FindAsync(id);
            if (dadosCaminhao != null)
            {
                _context.DadosCaminhoes.Remove(dadosCaminhao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DadosCaminhao> GetByIdAsync(int id)
        {
            return await _context.DadosCaminhoes.FindAsync(id);
        }

        public async Task UpdateAsync(DadosCaminhao dadosCaminhao)
        {
            _context.DadosCaminhoes.Update(dadosCaminhao);
            await _context.SaveChangesAsync();
        }
    }
}
