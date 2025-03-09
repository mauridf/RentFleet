using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.RegraDescontoJuros
{
    public class CreateRegraDescontoJurosCommand : IRequest<int>
    {
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
