using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDadosCaminhaoRepository
    {
        Task<DadosCaminhao> GetByIdAsync(int id);
        Task AddAsync(DadosCaminhao dadosCaminhao);
        Task UpdateAsync(DadosCaminhao dadosCaminhao);
        Task DeleteAsync(int id);
    }
}
