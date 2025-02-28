using RentFleet.Domain.Enums;
using System;

namespace RentFleet.Domain.Entities
{
    public class LocacaoVeiculo
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorBase { get; set; }
        public decimal Desconto { get; set; }
        public decimal Juros { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusLocacao StatusLocacao { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public decimal QuilometragemFinal { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Observacoes { get; set; }
    }
}