using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Recompensa
    {
        public int id { get; set; }
        public int experiencia { get; set; }
        public ICollection<Objetos>? objetos { get; set; }
        public ICollection<Enemigo>? enemigos { get; set; }
        public int monedas { get; set; }

        public Recompensa() {
            objetos = new Collection<Objetos>();
            enemigos = new Collection<Enemigo>();
        }
    }
}