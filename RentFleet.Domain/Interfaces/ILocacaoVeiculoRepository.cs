using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Interfaces
{
    public interface ILocacaoVeiculoRepository
    {
        Task<LocacaoVeiculo> GetByIdAsync(int id);
        Task<IEnumerable<LocacaoVeiculo>> GetAllByVeiculoIdAsync(int veiculoId);
        Task<IEnumerable<LocacaoVeiculo>> GetAllByClienteIdAsync(int clienteId);
        Task<LocacaoVeiculo?> GetUltimaLocacaoPorVeiculo(int veiculoId);
        Task<LocacaoVeiculo?> GetLocacaoAtivaPorVeiculo(int veiculoId);
        Task AddAsync(LocacaoVeiculo locacao);
        Task UpdateAsync(LocacaoVeiculo locacao);
        Task DeleteAsync(int id);
        Task<Dictionary<TipoVeiculo, int>> GetVeiculosMaisLocadosPorTipo();
        Task<List<LocacaoVeiculo>> GetLocacoesPorMes(int ano, int mes);
        Task<decimal> GetValorTotalLocacoesPorMes(int ano, int mes);
        Task<Dictionary<TipoVeiculo, decimal>> GetValorTotalLocacoesPorMesPorTipo(int ano, int mes);
        Task<int> GetTotalVeiculos();
        Task<int> GetVeiculosAtualmenteAlugados();
        Task<double> GetMediaDiasLocacao();
        Task<int> GetClienteComMaisLocacoes();
        Task<decimal> GetFaturamentoAnual(int ano);
        Task<int> GetQuantidadeLocacoesPorMes(int ano, int mes);
        Task<List<LocacaoVeiculo>> GetVeiculosLocados(); // 🔹 Veículos atualmente alugados
        Task<List<LocacaoVeiculo>> GetVeiculosDisponiveis(); // 🔹 Veículos disponíveis para nova locação
    }
}
