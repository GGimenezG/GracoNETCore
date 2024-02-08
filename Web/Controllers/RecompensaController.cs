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
    public class RecompensaController : ControllerBase
    {
        private IRecompensaService _servicio;

        public RecompensaController(IRecompensaService Recompensaervice){
           _servicio = Recompensaervice;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(){

            var Recompensa = await _servicio.GetAll();

            return Ok(Recompensa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Get(int id){

            var Recompensa = await _servicio.GetById(id);

            return Ok(Recompensa);
        }

        // POST api/<ObjetoController>
        [HttpPost]
        public async Task<ActionResult<Recompensa>> Post([FromBody] Recompensa Objeto)
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
        public async Task<ActionResult<Recompensa>> Put(int id, [FromBody] Recompensa Objeto){
            try{
                Recompensa updatedObjeto =
                    await _servicio.Update(id, Objeto);
                
                return updatedObjeto;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Recompensa>>> Delete(int id){

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