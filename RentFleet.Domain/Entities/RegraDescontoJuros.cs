using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Entities
{
    public class RegraDescontoJuros
    {
        public int Id { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public TipoRegra TipoRegra { get; set; } // Desconto ou Juros
        public decimal Percentual { get; set; }
        public string Descricao { get; set; }
    }
}