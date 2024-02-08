using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class TipoPersonaje
    {
        public int id {get;set;}
        public  string? nombre {get;set;}
        //public int fuerteContra {get;set;}
        //public  TipoPersonaje? fuerte { get;set;}
       // public int debilContra {get;set;}
        //public  TipoPersonaje debil {get;set;}

        public virtual ICollection<Personaje>? Personajes {get;set;}
        //public virtual ICollection<Enemigo>? Enemigos {get;set;}

        public TipoPersonaje(){
            Personajes = new Collection<Personaje>();
            //Enemigos = new Collection<Enemigo>();
        }
    }
}