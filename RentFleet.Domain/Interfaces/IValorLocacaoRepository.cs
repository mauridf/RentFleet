using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IValorLocacaoRepository
    {
        Task<ValorLocacao> GetByIdAsync(int id);
        Task<IEnumerable<ValorLocacao>> GetAllByTipoVeiculoAsync(string tipo);
        Task AddAsync(ValorLocacao valor);
        Task UpdateAsync(ValorLocacao valor);
        Task DeleteAsync(int id);
    }
}
