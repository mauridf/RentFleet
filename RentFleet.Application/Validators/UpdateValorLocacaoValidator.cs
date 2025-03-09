using FluentValidation;
using RentFleet.Application.Commands.ValorLocacao;

namespace RentFleet.Application.Validators
{
    public class UpdateValorLocacaoValidator : AbstractValidator<UpdateValorLocacaoCommand>
    {
        public UpdateValorLocacaoValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.TipoVeiculo).NotEmpty();
            RuleFor(v => v.Categoria).NotEmpty();
            RuleFor(v => v.ValorDiaria).NotEmpty();
        }
    }
}
