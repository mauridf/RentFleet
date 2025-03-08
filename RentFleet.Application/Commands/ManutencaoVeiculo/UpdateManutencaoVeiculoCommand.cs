using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.ManutencaoVeiculo
{
    public class UpdateManutencaoVeiculoCommand : IRequest
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataManutencao { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoManutencao TipoManutencao { get; set; }
        public string? Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Quilometragem { get; set; }
    }
}
