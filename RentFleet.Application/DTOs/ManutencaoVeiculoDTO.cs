using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.DTOs
{
    public class ManutencaoVeiculoDTO
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public DateTime DataManutencao { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
        public string? Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Quilometragem { get; set; }
    }
}
