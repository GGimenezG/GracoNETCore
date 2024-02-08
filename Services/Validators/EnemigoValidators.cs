using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class EnemigoValidators : AbstractValidator<Enemigo>
    {
        public EnemigoValidators(){
            RuleFor(x => x.defensa)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.defensa);

            RuleFor(x => x.estamina)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.estamina);
            
            RuleFor(x => x.fuerza)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.fuerza);
            
            RuleFor(x => x.inteligencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.inteligencia);

            RuleFor(x => x.resistencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.inteligencia)
                .WithMessage("El valor de la resistencia esta mal, por favor vovler a ingresar");

            RuleFor(x => x.experiencia)
                .LessThanOrEqualTo(Enemigo => Enemigo.nivel * 10 )
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.nivel)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.nivel)
                .WithMessage("nivel incorrecto");
                
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.tipoId)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.recompensaId)
                .GreaterThanOrEqualTo(1);
        }
    }
}