using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DocumentoDigitalizado
{
    public class GetDocumentoDigitalizadoByIdQuery : IRequest<DocumentoDigitalizadoDTO>
    {
        public int Id { get; set; }
    }
}
