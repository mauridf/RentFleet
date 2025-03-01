using FluentValidation;
using RentFleet.Application.Commands.Clientes;

namespace RentFleet.Application.Validators
{
    public class CreateClienteValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(c => c.CpfCnpj).NotEmpty().MaximumLength(14);
            RuleFor(c => c.Tipo).NotEmpty().MaximumLength(2);
            RuleFor(c => c.Endereco).NotEmpty().MaximumLength(200);
            RuleFor(c => c.Cidade).NotEmpty().MaximumLength(100);
            RuleFor(c => c.UF).NotEmpty().MaximumLength(2);
        }
    }
}
