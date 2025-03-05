using FluentValidation;
using RentFleet.Application.Commands.FotoVeiculo;

namespace RentFleet.Application.Validators
{
    public class CreateFotoVeiculoValidator : AbstractValidator<CreateFotoVeiculoCommand>
    {
        public CreateFotoVeiculoValidator()
        {
            RuleFor(f => f.VeiculoId).NotEmpty();
            RuleFor(f => f.UrlImagem).NotEmpty();
        }
    }
}
