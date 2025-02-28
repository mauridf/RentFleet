using RentFleet.Domain.Enums;

namespace RentFleet.Domain.Entities
{
    public class DadosTecnicosVeiculo
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public decimal PotenciaMotor { get; set; } // Em cavalos ou kW
        public int Cilindrada { get; set; } // Em cc
        public TipoTransmissao Transmissao { get; set; }
        public int NumeroMarchas { get; set; }
        public TipoTracao Tracao { get; set; }
        public decimal PesoBrutoTotal { get; set; } // Para caminhões
        public decimal CapacidadeCarga { get; set; } // Para caminhões
        public int NumeroEixos { get; set; } // Para caminhões
    }
}