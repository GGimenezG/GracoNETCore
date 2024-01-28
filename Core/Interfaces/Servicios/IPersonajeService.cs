using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IPersonajeService
    {
        Task<Personaje> GetPersonajeById(int id);
        Task<IEnumerable<Personaje>> GetAll();
        Task<Personaje> CreatePersonaje(Personaje newPersonaje);
        Task<Personaje> UpdatePersonaje(int personajeToBeUpdatedId, Personaje newPersonajeValues);
        Task DeletePersonaje(int personajeId);
        Task<Personaje> LevelUp(int personajeToBeUpdatedId, Personaje newPersonajeValues);
    }
}