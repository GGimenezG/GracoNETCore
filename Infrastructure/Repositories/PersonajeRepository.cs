using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PersonajeRepository : BaseRepository<Personaje>, IPersonajeRepository
    {
        public PersonajeRepository(AppDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Personaje>> GetAllAsync()
        {
            return await base.dbSet.Include(x => x.tipo).ToListAsync();
        }

        public async Task<IEnumerable<Personaje>> GetAllTipoAsync()
        {
            return await base.dbSet.Include(x => x.tipo).ToListAsync();
        }

    }
}