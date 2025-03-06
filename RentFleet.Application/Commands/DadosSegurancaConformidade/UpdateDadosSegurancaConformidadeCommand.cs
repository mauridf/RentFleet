using MediatR;
using RentFleet.Domain.Enums;

namespace RentFleet.Application.Commands.DadosSegurancaConformidade
{
    public class UpdateDadosSegurancaConformidadeCommand : IRequest
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataUltimaInspecao { get; set; }
        public StatusInspecao StatusInspecao { get; set; }
        public string NumeroSeguro { get; set; }
        public string Seguradora { get; set; }
        public DateTime ValidadeSeguro { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public DateTime ProximaManutencao { get; set; }
        public StatusVeiculo StatusVeiculo { get; set; }
    }
}
