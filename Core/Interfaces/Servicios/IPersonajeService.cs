using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;

namespace Core.Servicios
{
    public interface IPersonajeService : IBaseService<Personaje>
    {
        Task<Personaje> LevelUp(int personajeToBeUpdatedId, Personaje newPersonajeValues);
    }
}