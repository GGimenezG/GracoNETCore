using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Responses;
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

        public async Task<AtaqueResponse> Atacar(int idEnemigo, int idPersonaje){

            EnemigoService _servicioEnemigo = new EnemigoService(_unitOfWork);

            AtaqueResponse response = new AtaqueResponse();
            // buscar info enemico 
            var enemigo = await _unitOfWork.EnemigoRepository.GetByIdAsync(idEnemigo);
            var personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(idPersonaje);

            int mpAtaque = (int)((5 + personaje.nivel) * 1.2);

            if(Math.Abs(enemigo.nivel - personaje.nivel) <= 5){
                if(personaje.MP >= mpAtaque){
                    //bool aplicarDebilidad = personaje.tipo.fuerteContra == enemigo.tipo.id;
                   // bool aplicarDebilidadEnemigo = personaje.tipo.debilContra == enemigo.tipo.fuerteContra;
                    int puntosDaño = (int)(
                                        new List<string>() {"guerrero", "asesino"}.Contains(personaje.tipo?.nombre??"")
                                            ? (20 + personaje.fuerza) * 1.5
                                            : (35 + personaje.inteligencia) * 1.40
                                    ) - (int)(10 + enemigo.resistencia * 1.75);
                    enemigo.HP -=  puntosDaño;

                    if(enemigo.HP > 0) {
                        personaje.MP -= mpAtaque;
                        

                        //var respues = await _servicioEnemigo.Contrataque(asfasfasf);

                        int puntosDañoEnemigo = (int)(
                                        new List<string>() {"guerrero", "asesino"}.Contains(personaje.tipo?.nombre??"")
                                            ? (20 + enemigo.fuerza) * 1.5
                                            : (35 + enemigo.inteligencia) * 1.40
                                    ) - (int)(10 + personaje.resistencia * 1.75);
                        personaje.HP -= puntosDañoEnemigo;

                    }else{
                        personaje.experiencia += enemigo.experiencia;

                        if(personaje.nivel * 10 < personaje.experiencia){
                            Personaje personajeNuevo = personaje;

                            personajeNuevo.experiencia = 0;
                            personajeNuevo.nivel += 1;
                            personajeNuevo.HP = personaje.nivel * personaje.estamina + 50;
                            personajeNuevo.MP = personaje.nivel * 50;
                            personajeNuevo.inteligencia += new Random().Next(1,5);
                            personajeNuevo.resistencia += new Random().Next(1,5);
                            personajeNuevo.defensa += new Random().Next(1,5);
                            personajeNuevo.estamina += new Random().Next(1,5);
                            personajeNuevo.inteligencia += new Random().Next(1,5);
                            personajeNuevo.fuerza += new Random().Next(1,5);

                            await LevelUp(personaje.id, personajeNuevo);
                        }
                    }
                }
                else{

                    personaje.MP = (int)((personaje.MP + 15) * 1.30);

                    response.mensaje = "no hay sufiente mp para atacar, descansando este turno";
                }
                await _unitOfWork.CommitAsync();
            }
            else{
                response.mensaje = "No es posible atacar al enemigo ";
            }


            return response;
        }

        public async Task<Personaje> Create(Personaje newPersonaje)
        {
            PersonajeValidators validator = new();

            var validationResult = await validator.ValidateAsync(newPersonaje);
            if (validationResult.IsValid)
            {
                newPersonaje.tipo = await _unitOfWork.TipoPersonajeRepository.GetByIdAsync(newPersonaje.tipoId);

                if(newPersonaje.tipo != null ) {

                    await _unitOfWork.PersonajeRepository.AddAsync(newPersonaje);
                    await _unitOfWork.CommitAsync();
                }
                else {
                    throw new ArgumentException("El tipo de personaje no existe");
                }
            }
            else
            {
                
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage.ToString());
            }

            return newPersonaje;
        }

        public async Task Delete(int PersonajeId)
        {
            Personaje Personaje = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeId);
            _unitOfWork.PersonajeRepository.Remove(Personaje);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Personaje>> GetAll()
        {
            return await _unitOfWork.PersonajeRepository.GetAllAsync();
        }

        public async Task<Personaje> GetById(int id)
        {
            return await _unitOfWork.PersonajeRepository.GetByIdAsync(id);
        }

        public async Task<Personaje> Update(int PersonajeToBeUpdatedId, Personaje newPersonajeValues)
        {
            PersonajeValidators PersonajeValidator = new();
            
            var validationResult = await PersonajeValidator.ValidateAsync(newPersonajeValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Personaje PersonajeToBeUpdated = await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);

            if (PersonajeToBeUpdated == null)
                throw new ArgumentException("Invalid Personaje ID while updating");

            PersonajeToBeUpdated.tipoId = newPersonajeValues.tipoId;
            PersonajeToBeUpdated.nombre = newPersonajeValues.nombre;

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

            //await _unitOfWork.CommitAsync();

            return await _unitOfWork.PersonajeRepository.GetByIdAsync(PersonajeToBeUpdatedId);
        }
    }
}
