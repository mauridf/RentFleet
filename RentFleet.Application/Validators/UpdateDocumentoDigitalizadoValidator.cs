using FluentValidation;
using RentFleet.Application.Commands.DocumentoDigitalizado;

namespace RentFleet.Application.Validators
{
    public class UpdateDocumentoDigitalizadoValidator : AbstractValidator<UpdateDocumentoDigitalizadoCommand>
    {
        public UpdateDocumentoDigitalizadoValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.VeiculoId).NotEmpty();
            RuleFor(d => d.Descricao).MaximumLength(500);
            RuleFor(d => d.UrlDocumento).NotEmpty();
        }
    }
}
