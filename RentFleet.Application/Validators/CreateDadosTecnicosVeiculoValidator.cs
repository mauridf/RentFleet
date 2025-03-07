using FluentValidation;
using RentFleet.Application.Commands.DadosTecnicosVeiculo;

namespace RentFleet.Application.Validators
{
    public class CreateDadosTecnicosVeiculoValidator : AbstractValidator<CreateDadosTecnicosVeiculoCommand>
    {
        public CreateDadosTecnicosVeiculoValidator()
        {
            RuleFor(t => t.VeiculoId).NotEmpty();
            RuleFor(t => t.PotenciaMotor).NotEmpty();
            RuleFor(t => t.Cilindrada).NotEmpty();
            RuleFor(t => t.Transmissao).NotEmpty();
            RuleFor(t => t.NumeroMarchas).NotEmpty();
            RuleFor(t => t.Tracao).NotEmpty();
            RuleFor(t => t.PesoBrutoTotal).NotEmpty();
            RuleFor(t => t.CapacidadeCarga).NotEmpty();
            RuleFor(t => t.NumeroEixos).NotEmpty();
        }
    }
}
