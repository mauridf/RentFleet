using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IManutencaoVeiculoRepository
    {
        Task<ManutencaoVeiculo> GetByIdAsync(int id);
        Task<IEnumerable<ManutencaoVeiculo>> GetAllByVeiculoIdAsync(int veiculoId);
        Task<IEnumerable<ManutencaoVeiculo>> GetAllByTipoManutencaoAsync(string tipo);
        Task AddAsync(ManutencaoVeiculo manutencao);
        Task UpdateAsync(ManutencaoVeiculo manutencao);
        Task DeleteAsync(int id);
    }
}
