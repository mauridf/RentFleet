using MediatR;

namespace RentFleet.Application.Commands.DadosCaminhao
{
    public class DeleteDadosCaminhaoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
