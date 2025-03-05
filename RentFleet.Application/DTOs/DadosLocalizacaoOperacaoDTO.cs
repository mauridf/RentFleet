using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.DTOs
{
    public class DadosLocalizacaoOperacaoDTO
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public string? FilialRegistro { get; set; }
        public StatusLocacao StatusLocacao { get; set; }
        public DateTime DataAquisicao { get; set; }
        public decimal ValorAquisicao { get; set; }
        public decimal ValorLocacaoDiaria { get; set; }
        public string? Observacoes { get; set; }
    }
}
