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

        public async Task<ActionResult<IEnumerable<Personaje>>> Get(){

            var Personajes = await _servicio.GetAll();

            return Ok(Personajes);
        }

        public async Task<ActionResult<IEnumerable<Personaje>>> Get(int id){

            var Personajes = await _servicio.GetPersonajeById(id);

            return Ok(Personajes);
        }
    }
}