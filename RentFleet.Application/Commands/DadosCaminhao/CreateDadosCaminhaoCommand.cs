using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.DadosCaminhao
{
    public class CreateDadosCaminhaoCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoCaminhao TipoCaminhao { get; set; }
        public decimal ComprimentoCarroceria { get; set; }
        public decimal AlturaCarroceria { get; set; }
        public decimal LarguraCarroceria { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoCarroceria TipoCarroceria { get; set; }
    }
}
