using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Entities
{
    public class ValorLocacao
    {
        public int Id { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}