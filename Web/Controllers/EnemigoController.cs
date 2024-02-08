using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemigoController : ControllerBase
    {
        private IEnemigoService _servicio;

        public EnemigoController(IEnemigoService enemigoService){
           _servicio = enemigoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(){

            var enemigos = await _servicio.GetAll();

            return Ok(enemigos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Get(int id){

            var enemigos = await _servicio.GetById(id);

            return Ok(enemigos);
        }

        // POST api/<enemigoController>
        [HttpPost]
        public async Task<ActionResult<Enemigo>> Post([FromBody] Enemigo objEnemigo)
        {
            try
            {
                /*Enemigo objEnemigo = new Enemigo() {
                    nombre = enemigo.nombre,
                    recompensaId = enemigo.recompensaId,
                    resistencia = enemigo.resistencia,
                    tipoId = enemigo.tipoId,
                    defensa = enemigo.defensa,
                    nivel = enemigo.nivel,
                    MP = enemigo.MP,
                    inteligencia = enemigo.inteligencia,
                    id = enemigo.id,
                    HP = enemigo.HP,
                    fuerza = enemigo.fuerza,
                    experiencia = enemigo.experiencia,
                    estamina = enemigo.estamina
                };*/

                var createdenemigo =
                    await _servicio.Create(objEnemigo);

                return Ok(createdenemigo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Enemigo>> Put(int id, [FromBody] Enemigo enemigo){
            try{
                Enemigo updatedenemigo =
                    await _servicio.Update(id, enemigo);
                
                return updatedenemigo;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Enemigo>>> Delete(int id){

            try{
                await _servicio.Delete(id);
                return Ok("enemigo eliminado");

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }


        }
    }
}