using MediatR;

namespace RentFleet.Application.Commands.ValorLocacao
{
    public class DeleteValorLocacaoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
