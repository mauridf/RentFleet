using RentFleet.Domain.Enums;
using System;

namespace RentFleet.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public TipoVeiculo Tipo { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public decimal QuilometragemAtual { get; set; }
        public int NumeroPortas { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public TipoCombustivel Combustivel { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}