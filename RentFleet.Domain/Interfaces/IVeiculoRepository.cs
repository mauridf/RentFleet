using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetByIdAsync(int id);
        Task<Veiculo> GetByPlacaAsync(string placa);
        Task<Veiculo> GetByChassiAsync(string chassi);
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<IEnumerable<Veiculo>> GetAllByTipoAsync(string tipo);
        Task<IEnumerable<Veiculo>> GetAllByCategoriaAsync(string categoria);
        Task<IEnumerable<Veiculo>> GetAllByMarcaAsync(string marca);
        Task<IEnumerable<Veiculo>> GetAllByModeloAsync(string modelo);
        Task<IEnumerable<Veiculo>> GetAllByAnoFabricacaoModeloAsync(int? anoFabModel);
        Task<IEnumerable<Veiculo>> GetAllByCorAsync(string cor);
        Task<IEnumerable<Veiculo>> GetAllByNumeroPortasAsync(int portas);
        Task<IEnumerable<Veiculo>> GetAllByCombustivelAsync(string combustivel);
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(int id);
    }
}
