using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> GetByEmailAsync(string email);
        Task<Cliente> GetByNomeAsync(string nome);
        Task<Cliente> GetByCPFCNPJAsync(string cpfcnpj);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<IEnumerable<Cliente>> GetAllByCidadeAsync(string cidade);
        Task<IEnumerable<Cliente>> GetAllByUFAsync(string uf);
        Task<IEnumerable<Cliente>> GetAllByTipoAsync(string tipo);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
