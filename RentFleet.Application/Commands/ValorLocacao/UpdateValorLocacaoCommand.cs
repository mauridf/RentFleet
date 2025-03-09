using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.ValorLocacao
{
    public class UpdateValorLocacaoCommand : IRequest
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoVeiculo TipoVeiculo { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoriaVeiculo Categoria { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
