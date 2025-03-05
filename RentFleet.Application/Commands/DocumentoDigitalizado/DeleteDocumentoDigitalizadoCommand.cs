using MediatR;

namespace RentFleet.Application.Commands.DocumentoDigitalizado
{
    public class DeleteDocumentoDigitalizadoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
