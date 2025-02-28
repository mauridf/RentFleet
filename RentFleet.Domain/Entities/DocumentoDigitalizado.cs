namespace RentFleet.Domain.Entities
{
    public class DocumentoDigitalizado
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public string? Descricao { get; set; }
        public string UrlDocumento { get; set; }
    }
}