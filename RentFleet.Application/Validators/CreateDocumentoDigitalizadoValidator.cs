using FluentValidation;
using RentFleet.Application.Commands.DocumentoDigitalizado;

namespace RentFleet.Application.Validators
{
    public class CreateDocumentoDigitalizadoValidator : AbstractValidator<CreateDocumentoDigitalizadoCommand>
    {
        public CreateDocumentoDigitalizadoValidator()
        {
            RuleFor(d => d.VeiculoId).NotEmpty();
            RuleFor(d => d.Descricao).MaximumLength(500);
            RuleFor(d => d.UrlDocumento).NotEmpty();
        }
    }
}
