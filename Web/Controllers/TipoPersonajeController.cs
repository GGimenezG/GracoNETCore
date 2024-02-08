using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPersonajeController : ControllerBase
    {
        private ITipoPersonajeService _servicio;

        public TipoPersonajeController(ITipoPersonajeService TipoPersonajeervice){
           _servicio = TipoPersonajeervice;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersonaje>>> Get(){

            var TipoPersonaje = await _servicio.GetAll();

            return Ok(TipoPersonaje);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPersonaje>> Get(int id){

            var TipoPersonaje = await _servicio.GetById(id);

            return Ok(TipoPersonaje);
        }

        // POST api/<ObjetoController>
        [HttpPost]
        public async Task<ActionResult<TipoPersonaje>> Post([FromBody] TipoPersonaje Objeto)
        {
            try
            {
                var createdObjeto =
                    await _servicio.Create(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoPersonaje>> Put(int id, [FromBody] TipoPersonaje Objeto){
            try{
                TipoPersonaje updatedObjeto =
                    await _servicio.Update(id, Objeto);
                
                return updatedObjeto;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id){

            try{
                await _servicio.Delete(id);
                 //Ok(new TipoPersonaje());
                return Ok("Objeto eliminado");

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }


        }
    }
}