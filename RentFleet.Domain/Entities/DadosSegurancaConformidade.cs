using RentFleet.Domain.Enums;
using System;

namespace RentFleet.Domain.Entities
{
    public class DadosSegurancaConformidade
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public DateTime DataUltimaInspecao { get; set; }
        public StatusInspecao StatusInspecao { get; set; }
        public string NumeroSeguro { get; set; }
        public string Seguradora { get; set; }
        public DateTime ValidadeSeguro { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public DateTime ProximaManutencao { get; set; }
        public StatusVeiculo StatusVeiculo { get; set; }
    }
}