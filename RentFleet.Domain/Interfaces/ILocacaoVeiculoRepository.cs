using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface ILocacaoVeiculoRepository
    {
        Task<LocacaoVeiculo> GetByIdAsync(int id);
        Task<IEnumerable<LocacaoVeiculo>> GetAllByVeiculoIdAsync(int veiculoId);
        Task<IEnumerable<LocacaoVeiculo>> GetAllByClienteIdAsync(int clienteId);
        Task<LocacaoVeiculo?> GetUltimaLocacaoPorVeiculo(int veiculoId);
        Task<LocacaoVeiculo?> GetLocacaoAtivaPorVeiculo(int veiculoId);
        Task AddAsync(LocacaoVeiculo locacao);
        Task UpdateAsync(LocacaoVeiculo locacao);
        Task DeleteAsync(int id);
    }
}
