using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Objetos
    {
        public int id { get; set; }
        public  string? nombre { get; set; }
        public  string? descripcion { get; set; }
        public  int tipo { get; set; }
        public int valor { get; set; }

       
    }
}