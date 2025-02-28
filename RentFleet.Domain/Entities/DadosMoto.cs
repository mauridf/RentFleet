using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Entities
{
    public class DadosMoto
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public TipoMoto TipoMoto { get; set; }
        public decimal CapacidadeBagageiro { get; set; }
    }
}