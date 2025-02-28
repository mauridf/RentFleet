using FluentValidation;
using RentFleet.Application.Commands;

namespace RentFleet.Application.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Senha).NotEmpty();
        }
    }
}