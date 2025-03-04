using FluentValidation;
using RentFleet.Application.Commands.DadosMoto;

namespace RentFleet.Application.Validators
{
    public class UpdateDadosMotoValidator : AbstractValidator<UpdateDadosMotoCommand>
    {
        public UpdateDadosMotoValidator()
        {
            RuleFor(dm => dm.Id).NotEmpty();
            RuleFor(dm => dm.VeiculoId).NotEmpty();
            RuleFor(dm => dm.TipoMoto).NotEmpty();
            RuleFor(dm => dm.CapacidadeBagageiro).NotEmpty();
        }
    }
}
