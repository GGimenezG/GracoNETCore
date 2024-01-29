using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService _personajeService;
        public PersonajeController(IPersonajeService personajeService){
            _personajeService = personajeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personaje>>> Get()
        {
            var personajes = 
                        await _personajeService.GetAll();

            
            return Ok(personajes);
        }
    }
}