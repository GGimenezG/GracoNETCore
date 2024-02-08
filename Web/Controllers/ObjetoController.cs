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
    public class ObjetoController : ControllerBase
    {
        private IObjetosService _servicio;

        public ObjetoController(IObjetosService ObjetoService){
           _servicio = ObjetoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetos>>> Get(){

            var Objetos = await _servicio.GetAll();

            return Ok(Objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Objetos>>> Get(int id){

            var Objetos = await _servicio.GetById(id);

            return Ok(Objetos);
        }

        // POST api/<ObjetoController>
        [HttpPost]
        public async Task<ActionResult<Objetos>> Post([FromBody] Objetos Objeto)
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
        public async Task<ActionResult<Objetos>> Put(int id, [FromBody] Objetos Objeto){
            try{
                Objetos updatedObjeto =
                    await _servicio.Update(id, Objeto);
                
                return updatedObjeto;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Objetos>>> Delete(int id){

            try{
                await _servicio.Delete(id);
                return Ok("Objeto eliminado");

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }


        }
    }
}