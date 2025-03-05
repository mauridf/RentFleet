using FluentValidation;
using RentFleet.Application.Commands.FotoVeiculo;

namespace RentFleet.Application.Validators
{
    public class UpdateFotoVeiculoValidator : AbstractValidator<UpdateFotoVeiculoCommand>
    {
        public UpdateFotoVeiculoValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
            RuleFor(f => f.VeiculoId).NotEmpty();
            RuleFor(f => f.UrlImagem).NotEmpty();
        }
    }
}
