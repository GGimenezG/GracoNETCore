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
    public class RecompensaServices : IRecompensaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecompensaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Recompensa> Create(Recompensa newRecompensa)
        {
            RecompensaValidators validator = new();

            var validationResult = await validator.ValidateAsync(newRecompensa);
            if (validationResult.IsValid)
            {
                //newRecompensa.tipo = await _unitOfWork.TipoRecompensaRepository.GetByIdAsync(newRecompensa.tipoId);

                await _unitOfWork.RecompensaRepository.AddAsync(newRecompensa);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newRecompensa;
        }

        public async Task Delete(int RecompensaId)
        {
            Recompensa Recompensa = await _unitOfWork.RecompensaRepository.GetByIdAsync(RecompensaId);
            _unitOfWork.RecompensaRepository.Remove(Recompensa);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Recompensa>> GetAll()
        {
            return await _unitOfWork.RecompensaRepository.GetAllAsync();
        }

        public async Task<Recompensa> GetById(int id)
        {
            return await _unitOfWork.RecompensaRepository.GetByIdAsync(id);
        }

        public async Task<Recompensa> Update(int RecompensaToBeUpdatedId, Recompensa newRecompensaValues)
        {
            RecompensaValidators RecompensaValidator = new();
            
            var validationResult = await RecompensaValidator.ValidateAsync(newRecompensaValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Recompensa RecompensaToBeUpdated = await _unitOfWork.RecompensaRepository.GetByIdAsync(RecompensaToBeUpdatedId);

            if (RecompensaToBeUpdated == null)
                throw new ArgumentException("Invalid Recompensa ID while updating");

            RecompensaToBeUpdated.experiencia = newRecompensaValues.experiencia;
            RecompensaToBeUpdated.monedas = newRecompensaValues.monedas;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.RecompensaRepository.GetByIdAsync(RecompensaToBeUpdatedId);
        }
    }
}