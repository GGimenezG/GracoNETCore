using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Enemigo : Personaje
    {
        public int recompensaId {get; set;}
        public Recompensa? Recompensa { get; set; }
    }
}