using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entidades;
using Services.Services;
using Infrastructure.Data;
using Core.Servicios;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private IPersonajeService _servicio;

        public PersonajeController(IPersonajeService personajeService){
           _servicio = personajeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(){

            var Personajes = await _servicio.GetAll();

            return Ok(Personajes);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(int id){

            var Personajes = await _servicio.GetById(id);

            return Ok(Personajes);
        }

        // POST api/<PersonajeController>
        /// <summary>
        /// Método para crear un nuevo personaje
        /// </summary>
        /// <param name="personaje">Intancia de la clase Personaje</param>
        /// <returns>Objeto Personaje</returns>
        /// <remarks>
        /// Ejemplo de un Json Request
        /// {
        ///  "id": 0,
        ///  "nombre": "string",
        ///  "tipoId": 0,
        ///  "estamina": 0,
        ///  "inteligencia": 0,
        ///  "fuerza": 0,
        ///  "resistencia": 0,
        ///  "defensa": 0,
        ///  "experiencia": 0,
        ///  "nivel": 0,
        ///  "hp": 0,
        ///  "mp": 0
        ///}
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<Personaje>> Post([FromBody] Personaje personaje)
        {
            try
            {
                var createdPersonaje =
                    await _servicio.Create(personaje);

                return Ok(createdPersonaje);
            }
            catch(ArgumentException ex){
                return Ok(new { mensaje = ex.Message});
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message});
        
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otracosa"></param>
        /// <param name="personaje"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Personaje>> Put(int id, int otracosa, [FromBody] Personaje personaje){
            try{
                Personaje updatedPersonaje =
                    await _servicio.Update(id, personaje);
                
                return updatedPersonaje;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> Delete(int id){

            try{
                await _servicio.Delete(id);
                return Ok("Personaje eliminado");

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }


        } 
    }
}