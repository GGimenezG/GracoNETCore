using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje>, IPersonajeRepository
    {
        public PersonajeRepository(AppDbContext context) : base(context){
            
        }
    }
}