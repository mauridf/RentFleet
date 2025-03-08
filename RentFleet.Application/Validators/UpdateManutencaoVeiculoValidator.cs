using FluentValidation;
using RentFleet.Application.Commands.ManutencaoVeiculo;

namespace RentFleet.Application.Validators
{
    public class UpdateManutencaoVeiculoValidator : AbstractValidator<UpdateManutencaoVeiculoCommand>
    {
        public UpdateManutencaoVeiculoValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.VeiculoId).NotEmpty();
            RuleFor(m => m.DataManutencao).NotEmpty();
            RuleFor(m => m.TipoManutencao).NotEmpty();
            RuleFor(m => m.Descricao).MaximumLength(500);
            RuleFor(m => m.Custo).NotEmpty();
            RuleFor(m => m.Quilometragem).NotEmpty();
        }
    }
}
