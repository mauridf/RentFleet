﻿using RentFleet.Domain.Entities;

namespace RentFleet.Domain.Interfaces
{
    public interface IDadosMotoRepository
    {
        Task<DadosMoto> GetByIdAsync(int id);
        Task<DadosMoto> GetByVeiculoIdAsync(int veiculoId);
        Task AddAsync(DadosMoto dadosMoto);
        Task UpdateAsync(DadosMoto dadosMoto);
        Task DeleteAsync(int id);
    }
}
