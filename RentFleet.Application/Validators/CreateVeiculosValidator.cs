using FluentValidation;
using RentFleet.Application.Commands.Veiculo;

namespace RentFleet.Application.Validators
{
    public class CreateVeiculosValidator : AbstractValidator<CreateVeiculoCommand>
    {
        public CreateVeiculosValidator() 
        {
            RuleFor(v => v.Tipo).NotEmpty();
            RuleFor(v => v.Categoria).NotEmpty();
            RuleFor(v => v.Marca).NotEmpty().MaximumLength(100);
            RuleFor(v => v.Modelo).NotEmpty().MaximumLength(100);
            RuleFor(v => v.AnoFabricacao).NotEmpty();
            RuleFor(v => v.AnoModelo).NotEmpty();
            RuleFor(v => v.Cor).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Placa).NotEmpty().MaximumLength(8);
            RuleFor(v => v.Chassi).NotEmpty().MaximumLength(17);
            RuleFor(v => v.QuilometragemInicial).NotEmpty();
            RuleFor(v => v.QuilometragemAtual).NotEmpty();
            RuleFor(v => v.NumeroPortas).NotEmpty();
            RuleFor(v => v.CapacidadeTanque).NotEmpty();
            RuleFor(v => v.Combustivel).NotEmpty();
        }
    }
}
