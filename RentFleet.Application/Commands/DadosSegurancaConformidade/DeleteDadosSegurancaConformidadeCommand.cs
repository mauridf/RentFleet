using MediatR;

namespace RentFleet.Application.Commands.DadosSegurancaConformidade
{
    public class DeleteDadosSegurancaConformidadeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
