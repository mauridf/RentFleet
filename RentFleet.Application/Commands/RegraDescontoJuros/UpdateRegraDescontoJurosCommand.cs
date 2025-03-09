using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.RegraDescontoJuros
{
    public class UpdateRegraDescontoJurosCommand : IRequest
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoVeiculo TipoVeiculo { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoriaVeiculo Categoria { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoRegra TipoRegra { get; set; } // Desconto ou Juros
        public decimal Percentual { get; set; }
        public string Descricao { get; set; }
    }
}
