using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Servicios;
using Services.Validators;

namespace Services.Services
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonajeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Personaje> CreatePersonaje(Personaje newPersonaje)
        {
            PersonajeValidators validator = new();

            var validationResult = await validator.ValidateAsync(newPersonaje);
            if (validationResult.IsValid)
            {
                await _unitOfWork.PersonajeRepository.AddAsync(newPersonaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newPersonaje;
        }

        public async Task DeletePersonaje(int PersonajeId)
        {
            Personaje Personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeId);
            _unitOfWork.PersonajeRepository.Remove(Personaje);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Personaje>> GetAll()
        {
            return await _unitOfWork.PersonajeRepository.GetAllAsync();
        }

        public async Task<Personaje> GetPersonajeById(int id)
        {
            return await _unitOfWork.PersonajeRepository.GetByIdAsync(id);
        }

        public async Task<Personaje> UpdatePersonaje(int PersonajeToBeUpdatedId, Personaje newPersonajeValues)
        {
            PersonajeValidators PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.tipo = newPersonajeValues.tipo;
            PersonajeToBeUpdated.nombre = newPersonajeValues.tipo;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
        }

        public async Task<Personaje> LevelUp(int PersonajeToBeUpdatedId, Personaje newPersonajeValues)
        {
            PersonajeValidators PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.defensa = newPersonajeValues.defensa;
            PersonajeToBeUpdated.resistencia = newPersonajeValues.resistencia;
            PersonajeToBeUpdated.experiencia = newPersonajeValues.experiencia;
            PersonajeToBeUpdated.estamina = newPersonajeValues.estamina;
            PersonajeToBeUpdated.fuerza = newPersonajeValues.fuerza;
            PersonajeToBeUpdated.inteligencia = newPersonajeValues.inteligencia;
            PersonajeToBeUpdated.resistencia = newPersonajeValues.resistencia;
            PersonajeToBeUpdated.nivel = newPersonajeValues.resistencia;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
        }
    }
}
