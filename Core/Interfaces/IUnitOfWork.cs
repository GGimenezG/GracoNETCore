using Core.Interfaces.Repositorios;
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepository PersonajeRepository { get; }
        Task<int> CommitAsync();
    }