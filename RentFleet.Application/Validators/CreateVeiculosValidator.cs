using FluentValidation;
using RentFleet.Application.Commands.Veiculo;

namespace RentFleet.Application.Validators
{
    public class CreateVeiculosValidator : AbstractValidator<CreateVeiculoCommand>
    {
        public CreateVeiculosValidator() 
        {
            RuleFor(c => c.Tipo).NotEmpty();
            RuleFor(c => c.Categoria).NotEmpty();
            RuleFor(c => c.Marca).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Modelo).NotEmpty().MaximumLength(100);
            RuleFor(c => c.AnoFabricacao).NotEmpty();
            RuleFor(c => c.AnoModelo).NotEmpty();
            RuleFor(c => c.Cor).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Placa).NotEmpty().MaximumLength(8);
            RuleFor(c => c.Chassi).NotEmpty().MaximumLength(17);
            RuleFor(c => c.QuilometragemInicial).NotEmpty();
            RuleFor(c => c.QuilometragemAtual).NotEmpty();
            RuleFor(c => c.NumeroPortas).NotEmpty();
            RuleFor(c => c.CapacidadeTanque).NotEmpty();
            RuleFor(c => c.Combustivel).NotEmpty();
        }
    }
}
