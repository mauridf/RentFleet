using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDadosTecnicosVeiculoRepository
    {
        Task<DadosTecnicosVeiculo> GetByIdAsync(int id);
        Task<DadosTecnicosVeiculo> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(DadosTecnicosVeiculo dadosTecnicos);
        Task UpdateAsync(DadosTecnicosVeiculo dadosTecnicos);
        Task DeleteAsync(int id);
    }
}
