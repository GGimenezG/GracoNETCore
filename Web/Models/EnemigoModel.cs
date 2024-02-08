using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class EnemigoModel
    {
        public int id {get;set;}
        public required string nombre {get; set;}
        public int tipoId {get;set;}
        public int estamina {get;set;}
        public int inteligencia {get;set;}
        public int fuerza {get;set;}
        public int resistencia {get;set;}
        public int defensa {get;set;}
        public double experiencia {get;set;}
        public int nivel {get;set;}
        public int HP {get;set;}
        public int MP {get;set;}
        public int recompensaId {get; set;}

    }
}