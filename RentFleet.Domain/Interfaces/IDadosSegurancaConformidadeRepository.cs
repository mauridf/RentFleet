using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDadosSegurancaConformidadeRepository
    {
        Task<DadosSegurancaConformidade> GetByIdAsync(int id);
        Task<DadosSegurancaConformidade> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(DadosSegurancaConformidade segurancaConformidade);
        Task UpdateAsync(DadosSegurancaConformidade segurancaConformidade);
        Task DeleteAsync(int id);
    }
}
