using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDocumentoDigitalizadoRepository
    {
        Task<DocumentoDigitalizado> GetByIdAsync(int id);
        Task<List<DocumentoDigitalizado>> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(DocumentoDigitalizado documento);
        Task UpdateAsync(DocumentoDigitalizado documento);
        Task DeleteAsync(int id);
    }
}
