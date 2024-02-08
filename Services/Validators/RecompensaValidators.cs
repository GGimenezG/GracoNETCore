using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class RecompensaValidators: AbstractValidator<Recompensa>
    {
            public RecompensaValidators() {
                RuleFor(x => x.experiencia)
                    .LessThanOrEqualTo(100)
                    .GreaterThan(0);
                
                RuleFor(x => x.monedas)
                    .GreaterThanOrEqualTo(1);


            }
    }
}