using FluentValidation;
using RentFleet.Application.Commands;

namespace RentFleet.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.NomeAtendente).NotEmpty().MaximumLength(100);
            RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(u => u.Senha).NotEmpty().MaximumLength(100);
            RuleFor(u => u.Tipo).NotEmpty().MaximumLength(50);
        }
    }
}