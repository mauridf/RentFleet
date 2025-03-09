using FluentValidation;
using RentFleet.Application.Commands.ValorLocacao;

namespace RentFleet.Application.Validators
{
    public class CreateValoLocacaoValidator : AbstractValidator<CreateValorLocacaoCommand>
    {
        public CreateValoLocacaoValidator()
        {
            RuleFor(v => v.TipoVeiculo).NotEmpty();
            RuleFor(v => v.Categoria).NotEmpty();
            RuleFor(v => v.ValorDiaria).NotEmpty();
        }
    }
}
