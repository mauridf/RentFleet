using RentFleet.Domain.Enums;
using System;

namespace RentFleet.Domain.Entities
{
    public class ManutencaoVeiculo
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