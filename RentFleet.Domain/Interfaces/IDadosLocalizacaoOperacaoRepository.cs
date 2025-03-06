using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDadosLocalizacaoOperacaoRepository
    {
        Task<DadosLocalizacaoOperacao> GetByIdAsync(int id);
        Task<DadosLocalizacaoOperacao> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(DadosLocalizacaoOperacao dadosLocOper);
        Task UpdateAsync(DadosLocalizacaoOperacao dadosLocOper);
        Task DeleteAsync(int id);
    }
}
