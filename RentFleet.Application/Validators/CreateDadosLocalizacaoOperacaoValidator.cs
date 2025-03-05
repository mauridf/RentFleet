using FluentValidation;
using RentFleet.Application.Commands.DadosLocalizacaoOperacao;

namespace RentFleet.Application.Validators
{
    public class CreateDadosLocalizacaoOperacaoValidator : AbstractValidator<CreateDadosLocalizacaoOperacaoCommand>
    {
        public CreateDadosLocalizacaoOperacaoValidator()
        {
            RuleFor(dlo => dlo.VeiculoId).NotEmpty();
            RuleFor(dlo => dlo.FilialRegistro).MaximumLength(200);
            RuleFor(dlo => dlo.StatusLocacao).NotEmpty();
            RuleFor(dlo => dlo.DataAquisicao).NotEmpty();
            RuleFor(dlo => dlo.ValorAquisicao).NotNull();
            RuleFor(dlo => dlo.ValorLocacaoDiaria).NotNull();
            RuleFor(dlo => dlo.Observacoes).MaximumLength(500);
        }
    }
}
