using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Interfaces
{
    public interface IRegraDescontoJurosRepository
    {
        Task<RegraDescontoJuros> GetByIdAsync(int id);
        Task<IEnumerable<RegraDescontoJuros>> GetAllByTipoRegraAsync(string tipo);
        Task<RegraDescontoJuros?> GetByTipoCategoriaAsync(TipoVeiculo tipo, CategoriaVeiculo categoria);
        Task AddAsync(RegraDescontoJuros regras);
        Task UpdateAsync(RegraDescontoJuros regras);
        Task DeleteAsync(int id);
    }
}
