using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IRegraDescontoJurosRepository
    {
        Task<RegraDescontoJuros> GetByIdAsync(int id);
        Task<IEnumerable<RegraDescontoJuros>> GetAllByTipoRegraAsync(string tipo);
        Task AddAsync(RegraDescontoJuros regras);
        Task UpdateAsync(RegraDescontoJuros regras);
        Task DeleteAsync(int id);
    }
}
