using MediatR;

namespace RentFleet.Application.Commands.DadosMoto
{
    public class DeleteDadosMotoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
