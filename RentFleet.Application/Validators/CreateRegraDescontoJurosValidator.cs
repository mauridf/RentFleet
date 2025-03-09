using FluentValidation;
using RentFleet.Application.Commands.RegraDescontoJuros;

namespace RentFleet.Application.Validators
{
    public class CreateRegraDescontoJurosValidator : AbstractValidator<CreateRegraDescontoJurosCommand>
    {
        public CreateRegraDescontoJurosValidator()
        {
            RuleFor(m => m.TipoVeiculo).NotEmpty();
            RuleFor(m => m.Categoria).NotEmpty();
            RuleFor(m => m.TipoRegra).NotEmpty();
            RuleFor(m => m.Percentual).NotEmpty();
            RuleFor(m => m.Descricao).NotEmpty();
        }
    }
}
