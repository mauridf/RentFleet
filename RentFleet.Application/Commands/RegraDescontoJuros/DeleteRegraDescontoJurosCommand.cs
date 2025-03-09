using MediatR;
using RentFleet.Domain.Enums;
using System.Text.Json.Serialization;

namespace RentFleet.Application.Commands.RegraDescontoJuros
{
    public class DeleteRegraDescontoJurosCommand : IRequest
    {
        public int Id { get; set; }
    }
}
