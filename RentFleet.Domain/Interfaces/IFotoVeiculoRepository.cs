using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IFotoVeiculoRepository
    {
        Task<FotoVeiculo> GetByIdAsync(int id);
        Task<List<FotoVeiculo>> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(FotoVeiculo foto);
        Task UpdateAsync(FotoVeiculo foto);
        Task DeleteAsync(int id);
    }
}
