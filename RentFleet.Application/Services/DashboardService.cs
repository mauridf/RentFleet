using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;

namespace RentFleet.Application.Services
{
    public class DashboardService
    {
        private readonly ILocacaoVeiculoRepository _locacaoRepository;

        public DashboardService(ILocacaoVeiculoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<DashboardDTO> GetDashboardData(int ano, int mes)
        {
            var totalLocacoes = await _locacaoRepository.GetValorTotalLocacoesPorMes(ano, mes);
            var totalLocacoesPorTipo = await _locacaoRepository.GetValorTotalLocacoesPorMesPorTipo(ano, mes);
            var veiculosMaisLocados = await _locacaoRepository.GetVeiculosMaisLocadosPorTipo();

            var totalVeiculos = await _locacaoRepository.GetTotalVeiculos();
            var veiculosAlugados = await _locacaoRepository.GetVeiculosAtualmenteAlugados();
            var percentualOcupacao = totalVeiculos > 0 ? (veiculosAlugados / (double)totalVeiculos) * 100 : 0;

            var mediaDiasLocacao = await _locacaoRepository.GetMediaDiasLocacao();
            var clienteMaisLocacoes = await _locacaoRepository.GetClienteComMaisLocacoes();
            var faturamentoAnual = await _locacaoRepository.GetFaturamentoAnual(ano);
            var quantidadeLocacoesMes = await _locacaoRepository.GetQuantidadeLocacoesPorMes(ano, mes);

            return new DashboardDTO
            {
                TotalLocacoes = totalLocacoes,
                TotalLocacoesPorTipo = totalLocacoesPorTipo,
                VeiculosMaisLocados = veiculosMaisLocados,
                PercentualOcupacaoFrota = percentualOcupacao,
                MediaDiasLocacao = mediaDiasLocacao,
                ClienteMaisLocacoes = clienteMaisLocacoes,
                FaturamentoAnual = faturamentoAnual,
                QuantidadeLocacoesMes = quantidadeLocacoesMes
            };
        }

        public async Task<List<RentFleet.Domain.Entities.LocacaoVeiculo>> GetLocacoesPorMes(int ano, int mes)
        {
            return await _locacaoRepository.GetLocacoesPorMes(ano, mes);
        }
    }
}
