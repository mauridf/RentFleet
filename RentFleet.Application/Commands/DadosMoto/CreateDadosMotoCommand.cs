using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.DadosMoto
{
    public class CreateDadosMotoCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoMoto TipoMoto { get; set; }
        public decimal CapacidadeBagageiro { get; set; }
    }
}
