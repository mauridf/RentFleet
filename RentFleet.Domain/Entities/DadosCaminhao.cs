using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Entities
{
    public class DadosCaminhao
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public TipoCaminhao TipoCaminhao { get; set; }
        public decimal ComprimentoCarroceria { get; set; }
        public decimal AlturaCarroceria { get; set; }
        public decimal LarguraCarroceria { get; set; }
        public TipoCarroceria TipoCarroceria { get; set; }
    }
}