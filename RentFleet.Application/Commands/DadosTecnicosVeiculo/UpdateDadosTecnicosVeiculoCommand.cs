using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.DadosTecnicosVeiculo
{
    public class UpdateDadosTecnicosVeiculoCommand : IRequest
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public decimal PotenciaMotor { get; set; } // Em cavalos ou kW
        public int Cilindrada { get; set; } // Em cc
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoTransmissao Transmissao { get; set; }
        public int NumeroMarchas { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoTracao Tracao { get; set; }
        public decimal PesoBrutoTotal { get; set; } // Para caminhões
        public decimal CapacidadeCarga { get; set; } // Para caminhões
        public int NumeroEixos { get; set; } // Para caminhões
    }
}
