using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.Reserva
{
    public class CreateReservaCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusReserva StatusReserva { get; set; }
    }
}
