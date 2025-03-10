using RentFleet.Domain.Enums;

namespace RentFleet.Application.DTOs
{
    public class DashboardDTO
    {
        public decimal TotalLocacoes { get; set; }
        public Dictionary<TipoVeiculo, decimal> TotalLocacoesPorTipo { get; set; }
        public Dictionary<TipoVeiculo, int> VeiculosMaisLocados { get; set; }
        public double PercentualOcupacaoFrota { get; set; }
        public double MediaDiasLocacao { get; set; }
        public int ClienteMaisLocacoes { get; set; }
        public decimal FaturamentoAnual { get; set; }
        public int QuantidadeLocacoesMes { get; set; }
    }
}
