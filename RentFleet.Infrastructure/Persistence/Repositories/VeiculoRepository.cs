using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using RentFleet.Infrastructure.Persistence.Contexts;

namespace RentFleet.Infrastructure.Persistence.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly RentFleetDbContext _context;

        public VeiculoRepository(RentFleetDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByAnoFabricacaoModeloAsync(int? anoFabModel)
        {
            return await _context.Veiculos
                .Where(v => v.AnoFabricacao == anoFabModel || v.AnoModelo == anoFabModel)
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByCategoriaAsync(string categoria)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Categoria.ToString(), categoria))
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByCombustivelAsync(string combustivel)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Combustivel.ToString(), combustivel))
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByCorAsync(string cor)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Cor, cor))
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByMarcaAsync(string marca)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Marca, marca))
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByModeloAsync(string modelo)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Modelo, modelo))
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByNumeroPortasAsync(int portas)
        {
            return await _context.Veiculos
                .Where(v => v.NumeroPortas == portas)
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllByTipoAsync(string tipo)
        {
            return await _context.Veiculos
                .Where(v => EF.Functions.Like(v.Tipo.ToString(), tipo))
                .ToListAsync();
        }

        public async Task<Veiculo> GetByChassiAsync(string chassi)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.Chassi == chassi);
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task<Veiculo> GetByPlacaAsync(string placa)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
