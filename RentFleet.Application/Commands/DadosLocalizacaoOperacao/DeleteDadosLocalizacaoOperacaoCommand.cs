using MediatR;

namespace RentFleet.Application.Commands.DadosLocalizacaoOperacao
{
    public class DeleteDadosLocalizacaoOperacaoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
