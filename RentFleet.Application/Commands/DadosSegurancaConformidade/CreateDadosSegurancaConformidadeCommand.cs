using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.DadosSegurancaConformidade
{
    public class CreateDadosSegurancaConformidadeCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        public DateTime DataUltimaInspecao { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusInspecao StatusInspecao { get; set; }
        public string NumeroSeguro { get; set; }
        public string Seguradora { get; set; }
        public DateTime ValidadeSeguro { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public DateTime ProximaManutencao { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusVeiculo StatusVeiculo { get; set; }
    }
}
