using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class TipoPersonajeValidators : AbstractValidator<TipoPersonaje>
    {
        public TipoPersonajeValidators(){
                RuleFor(x => x.nombre)
                    .NotEmpty()
                    .MaximumLength(20);

                /*RuleFor(t => t.fuerteContra)
                    .GreaterThan(0);*/

                //RuleFor(t => t.debilContra)
                //    .GreaterThan(0);

        }
    }
}