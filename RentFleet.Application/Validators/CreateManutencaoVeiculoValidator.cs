using FluentValidation;
using RentFleet.Application.Commands.ManutencaoVeiculo;

namespace RentFleet.Application.Validators
{
    public class CreateManutencaoVeiculoValidator : AbstractValidator<CreateManutencaoVeiculoCommand>
    {
        public CreateManutencaoVeiculoValidator()
        {
            RuleFor(m => m.VeiculoId).NotEmpty();
            RuleFor(m => m.DataManutencao).NotEmpty();
            RuleFor(m => m.TipoManutencao).NotEmpty();
            RuleFor(m => m.Descricao).MaximumLength(500);
            RuleFor(m => m.Custo).NotEmpty();
            RuleFor(m => m.Quilometragem).NotEmpty();
        }
    }
}
