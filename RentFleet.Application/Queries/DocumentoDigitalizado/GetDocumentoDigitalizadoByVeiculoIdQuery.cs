using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries.DocumentoDigitalizado
{
    public class GetDocumentoDigitalizadoByVeiculoIdQuery : IRequest<List<DocumentoDigitalizadoDTO>>
    {
        public int VeiculoId { get; set; }
    }
}
