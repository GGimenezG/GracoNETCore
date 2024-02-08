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
        private EnemigoRepository  _enemigoRepository;
        private ObjetosRepository  _objetoRepository;
        private RecompensaRepository  _recompensaRepository;
        private TipoPersonajeRepository  _tipoPersonajeRepository;
        
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPersonajeRepository PersonajeRepository => _personajeRepository ??= new PersonajeRepository(_context);
        public IEnemigoRepository EnemigoRepository => _enemigoRepository ??= new EnemigoRepository(_context);
        public IObjetosRepository ObjetosRepository => _objetoRepository ??= new ObjetosRepository(_context);
        public IRecompensaRepository RecompensaRepository => _recompensaRepository ??= new RecompensaRepository(_context);
        public ITipoPersonajeRepository TipoPersonajeRepository => _tipoPersonajeRepository ??= new TipoPersonajeRepository(_context);
        
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