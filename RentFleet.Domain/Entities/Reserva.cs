using RentFleet.Domain.Enums;
using System;

namespace RentFleet.Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public StatusReserva StatusReserva { get; set; }
    }
}