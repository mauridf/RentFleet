using FluentValidation;
using RentFleet.Application.Commands.DadosCaminhao;

namespace RentFleet.Application.Validators
{
    public class UpdateDadosCaminhaoValidator : AbstractValidator<UpdateDadosCaminhaoCommand>
    {
        public UpdateDadosCaminhaoValidator()
        {
            RuleFor(dc => dc.Id).NotEmpty();
            RuleFor(dc => dc.VeiculoId).NotEmpty();
            RuleFor(dc => dc.TipoCaminhao).NotEmpty();
            RuleFor(dc => dc.ComprimentoCarroceria).NotEmpty();
            RuleFor(dc => dc.AlturaCarroceria).NotEmpty();
            RuleFor(dc => dc.TipoCarroceria).NotEmpty();
        }
    }
}
