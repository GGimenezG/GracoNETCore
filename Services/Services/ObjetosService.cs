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
    public class ObjetosService : IObjetosService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ObjetosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Objetos> Create(Objetos newObjetos)
        {
            ObjetosValidators validator = new();

            var validationResult = await validator.ValidateAsync(newObjetos);
            if (validationResult.IsValid)
            {
                //newObjetos.tipo = await _unitOfWork.TipoObjetosRepository.GetByIdAsync(newObjetos.tipoId);

                await _unitOfWork.ObjetosRepository.AddAsync(newObjetos);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newObjetos;
        }

        public async Task Delete(int ObjetosId)
        {
            Objetos Objetos = await _unitOfWork.ObjetosRepository.GetByIdAsync(ObjetosId);
            _unitOfWork.ObjetosRepository.Remove(Objetos);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Objetos>> GetAll()
        {
            return await _unitOfWork.ObjetosRepository.GetAllAsync();
        }

        public async Task<Objetos> GetById(int id)
        {
            return await _unitOfWork.ObjetosRepository.GetByIdAsync(id);
        }

        public async Task<Objetos> Update(int ObjetosToBeUpdatedId, Objetos newObjetosValues)
        {
            ObjetosValidators ObjetosValidator = new();
            
            var validationResult = await ObjetosValidator.ValidateAsync(newObjetosValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Objetos ObjetosToBeUpdated = await _unitOfWork.ObjetosRepository.GetByIdAsync(ObjetosToBeUpdatedId);

            if (ObjetosToBeUpdated == null)
                throw new ArgumentException("Invalid Objetos ID while updating");

            ObjetosToBeUpdated.descripcion = newObjetosValues.descripcion;
            ObjetosToBeUpdated.nombre = newObjetosValues.nombre;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.ObjetosRepository.GetByIdAsync(ObjetosToBeUpdatedId);
        }



    }
}