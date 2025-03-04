using FluentValidation;
using RentFleet.Application.Commands.DadosMoto;

namespace RentFleet.Application.Validators
{
    public class CreateDadosMotoValidator : AbstractValidator<CreateDadosMotoCommand>
    {
        public CreateDadosMotoValidator()
        {
            RuleFor(dm => dm.VeiculoId).NotEmpty();
            RuleFor(dm => dm.TipoMoto).NotEmpty();
            RuleFor(dm => dm.CapacidadeBagageiro).NotEmpty();
        }
    }
}
