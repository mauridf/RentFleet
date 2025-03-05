using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.DadosLocalizacaoOperacao
{
    public class CreateDadosLocalizacaoOperacaoCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        public string? FilialRegistro { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusLocacao StatusLocacao { get; set; }
        public DateTime DataAquisicao { get; set; }
        public decimal ValorAquisicao { get; set; }
        public decimal ValorLocacaoDiaria { get; set; }
        public string? Observacoes { get; set; }
    }
}
