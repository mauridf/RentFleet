using RentFleet.Domain.Enums;

namespace RentFleet.Application.DTOs
{
    public class ValorLocacaoDTO
    {
        public int Id { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
