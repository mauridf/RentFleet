using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> GetByIdAsync(int id);
        Task<IEnumerable<Reserva>> GetAllByVeiculoIdAsync(int veiculoId);
        Task<IEnumerable<Reserva>> GetAllByClienteIdAsync(int clienteId);
        Task AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(int id);
    }
}
