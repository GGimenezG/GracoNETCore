using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje>
    {
        public PersonajeRepository(AppDbContext context) : base(context){
            
        }
    }
}