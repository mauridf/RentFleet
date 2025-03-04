using RentFleet.Domain.Entities;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.DTOs
{
    public class DadosMotoDTO
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public TipoMoto TipoMoto { get; set; }
        public decimal CapacidadeBagageiro { get; set; }
    }
}
