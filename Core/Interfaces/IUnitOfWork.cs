using Core.Interfaces.Repositorios;
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepository PersonajeRepository { get; }
        IEnemigoRepository EnemigoRepository {get;}
        IObjetosRepository ObjetosRepository {get;}
        IRecompensaRepository RecompensaRepository {get;}
        ITipoPersonajeRepository TipoPersonajeRepository {get;}
        Task<int> CommitAsync();
    }