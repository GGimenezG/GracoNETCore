using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Servicios;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {

       private readonly PersonajeService _personajeService;
        private readonly UnitOfWork _unitOfWork;
        private readonly AppDbContext _db;
        public PersonajeController(){
            _db = new AppDbContext(new DbContextOptions<AppDbContext>(){
                
            });
            _unitOfWork = new UnitOfWork(_db);
            _personajeService = new PersonajeService(_unitOfWork);
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