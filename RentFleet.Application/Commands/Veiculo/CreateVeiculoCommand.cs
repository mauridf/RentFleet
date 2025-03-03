using System.Text.Json.Serialization;
using MediatR;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.Commands.Veiculo
{
    public class CreateVeiculoCommand : IRequest<int>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoVeiculo Tipo { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoriaVeiculo Categoria { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public decimal QuilometragemAtual { get; set; }
        public int NumeroPortas { get; set; }
        public decimal CapacidadeTanque { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoCombustivel Combustivel { get; set; }
    }
}