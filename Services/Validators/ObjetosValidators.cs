using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class ObjetosValidators: AbstractValidator<Objetos>
    {
        public ObjetosValidators()
        {
            RuleFor(objeto => objeto.valor)
                .GreaterThan(0);

            RuleFor(objeto => objeto.tipo)
                .GreaterThanOrEqualTo(0);

            RuleFor(objeto => objeto.nombre)
                .NotEmpty()
                .MaximumLength(40);
            RuleFor(objeto => objeto.descripcion)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}