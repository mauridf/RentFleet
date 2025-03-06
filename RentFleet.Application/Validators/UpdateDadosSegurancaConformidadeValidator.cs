using FluentValidation;
using RentFleet.Application.Commands.DadosSegurancaConformidade;

namespace RentFleet.Application.Validators
{
    public class UpdateDadosSegurancaConformidadeValidator : AbstractValidator<UpdateDadosSegurancaConformidadeCommand>
    {
        public UpdateDadosSegurancaConformidadeValidator()
        {
            RuleFor(sc => sc.Id).NotEmpty();
            RuleFor(sc => sc.VeiculoId).NotEmpty();
            RuleFor(sc => sc.DataUltimaInspecao).NotEmpty();
            RuleFor(sc => sc.StatusInspecao).NotEmpty();
            RuleFor(sc => sc.NumeroSeguro).MaximumLength(20).NotEmpty();
            RuleFor(sc => sc.Seguradora).MaximumLength(100).NotNull();
            RuleFor(sc => sc.ValidadeSeguro).NotNull();
            RuleFor(sc => sc.DataUltimaManutencao).NotNull();
            RuleFor(sc => sc.ProximaManutencao).NotNull();
            RuleFor(sc => sc.StatusVeiculo).NotNull();
        }
    }
}
