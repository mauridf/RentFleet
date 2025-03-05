﻿using FluentValidation;
using RentFleet.Application.Commands.DocumentoDigitalizado;

namespace RentFleet.Application.Validators
{
    public class UpdateDocumentoDigitalizadoValidator : AbstractValidator<UpdateDocumentoDigitalizadoCommand>
    {
        public UpdateDocumentoDigitalizadoValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.VeiculoId).NotEmpty();
            RuleFor(d => d.Descricao).NotEmpty();
            RuleFor(d => d.UrlDocumento).NotEmpty();
        }
    }
}
