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


        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get(int id){

            var Personajes = await _servicio.GetById(id);

            return Ok(Personajes);
        }

        // POST api/<PersonajeController>
        /// <summary>
        /// COsas a actualizar
        /// </summary>
        /// <param name="id">Prueba</param>
        /// <returns>Algo para devolver</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
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