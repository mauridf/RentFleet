using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Interfaces
{
    public interface IValorLocacaoRepository
    {
        Task<ValorLocacao> GetByIdAsync(int id);
        Task<IEnumerable<ValorLocacao>> GetAllByTipoVeiculoAsync(string tipo);
        Task<ValorLocacao?> GetByTipoCategoriaAsync(TipoVeiculo tipo, CategoriaVeiculo categoria);
        Task AddAsync(ValorLocacao valor);
        Task UpdateAsync(ValorLocacao valor);
        Task DeleteAsync(int id);
    }
}
