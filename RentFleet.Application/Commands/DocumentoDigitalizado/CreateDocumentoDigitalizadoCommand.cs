using Amazon.Runtime.Internal;
using MediatR;

namespace RentFleet.Application.Commands.DocumentoDigitalizado
{
    public class CreateDocumentoDigitalizadoCommand : IRequest<int>
    {
        public int VeiculoId { get; set; }
        public string? Descricao { get; set; }
        public string UrlDocumento { get; set; }
    }
}
