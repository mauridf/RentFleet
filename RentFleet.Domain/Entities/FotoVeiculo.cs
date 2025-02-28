namespace RentFleet.Domain.Entities
{
    public class FotoVeiculo
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public string UrlImagem { get; set; }
    }
}