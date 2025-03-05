using RentFleet.Domain.Entities;

namespace RentFleet.Application.DTOs
{
    public class FotoVeiculoDTO
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public string UrlImagem { get; set; }
    }
}
