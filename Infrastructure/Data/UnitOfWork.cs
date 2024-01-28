using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Infrastructure.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private PersonajeRepository  _personajeRepository;
        
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPersonajeRepository PersonajeRepository => _personajeRepository ??= new PersonajeRepository(_context);
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}