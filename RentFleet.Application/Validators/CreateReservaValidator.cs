using FluentValidation;
using RentFleet.Application.Commands.Reserva;

namespace RentFleet.Application.Validators
{
    public class CreateReservaValidator : AbstractValidator<CreateReservaCommand>
    {
        public CreateReservaValidator()
        {
            RuleFor(r => r.VeiculoId).NotEmpty();
            RuleFor(r => r.ClienteId).NotEmpty();
            RuleFor(r => r.DataReserva).NotEmpty();
            RuleFor(r => r.DataInicio).NotEmpty();
            RuleFor(r => r.DataFim).NotEmpty();
            RuleFor(r => r.StatusReserva).NotEmpty();
        }
    }
}
