using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class PersonajeValidators : AbstractValidator<Personaje>
    {
        public PersonajeValidators()
        {
            RuleFor(x => x.defensa)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.defensa);

            RuleFor(x => x.estamina)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.estamina);
            
            RuleFor(x => x.fuerza)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.fuerza);
            
            RuleFor(x => x.inteligencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.inteligencia);

            RuleFor(x => x.resistencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Personaje => Personaje.inteligencia);

            RuleFor(x => x.experiencia)
                .LessThanOrEqualTo(Personaje => Personaje.nivel * 10 )
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.nivel)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Personaje => Personaje.nivel);
                
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.tipo)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}