using MediatR;

namespace RentFleet.Application.Commands.DocumentoDigitalizado
{
    public class UpdateDocumentoDigitalizadoCommand : IRequest
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public string? Descricao { get; set; }
        public string UrlDocumento { get; set; }
    }
}
