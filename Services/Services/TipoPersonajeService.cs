using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Servicios;
using Services.Validators;

namespace Services.Services
{
    public class TipoPersonajeService : ITipoPersonajeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoPersonajeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<TipoPersonaje> Create(TipoPersonaje newTipoPersonaje)
        {
            TipoPersonajeValidators validator = new();

            var validationResult = await validator.ValidateAsync(newTipoPersonaje);
            if (validationResult.IsValid)
            {
                //newTipoPersonaje.tipo = await _unitOfWork.TipoTipoPersonajeRepository.GetByIdAsync(newTipoPersonaje.tipoId);

                await _unitOfWork.TipoPersonajeRepository.AddAsync(newTipoPersonaje);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newTipoPersonaje;
        }

        public async Task Delete(int TipoPersonajeId)
        {
            TipoPersonaje TipoPersonaje = await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(TipoPersonajeId);
            _unitOfWork.TipoPersonajeRepository.Remove(TipoPersonaje);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TipoPersonaje>> GetAll()
        {
            return await _unitOfWork.TipoPersonajeRepository.GetAllAsync();
        }

        public async Task<TipoPersonaje> GetById(int id)
        {
            return await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(id);
        }

        public async Task<TipoPersonaje> Update(int TipoPersonajeToBeUpdatedId, TipoPersonaje newTipoPersonajeValues)
        {
            TipoPersonajeValidators TipoPersonajeValidator = new();
            
            var validationResult = await TipoPersonajeValidator.ValidateAsync(newTipoPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            TipoPersonaje TipoPersonajeToBeUpdated = await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(TipoPersonajeToBeUpdatedId);

            if (TipoPersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid TipoPersonaje ID while updating");

            //TipoPersonajeToBeUpdated.fuerteContra = newTipoPersonajeValues.fuerteContra;
            //TipoPersonajeToBeUpdated.debilContra = newTipoPersonajeValues.debilContra;
            TipoPersonajeToBeUpdated.nombre = newTipoPersonajeValues.nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(TipoPersonajeToBeUpdatedId);
        }
    }
}