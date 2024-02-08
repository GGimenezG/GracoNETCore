using Core.Entidades;
namespace Core.Interfaces.Repositorios;
    public interface IPersonajeRepository : IBaseRepository<Personaje>{

        Task<IEnumerable<Personaje>> GetAllTipoAsync();

    }


