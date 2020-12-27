using APIRest.Web.data;
using APIRest.Web.data.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Web.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EstudiantesController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await _dataContext.Estudiantes.ToListAsync();
        }

        [HttpGet("{id}/{codigo}", Name = "GetEstudiantes")]
        public async Task<IActionResult> Get(int id)
        {
            var estudiante = await _dataContext.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(estudiante);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _dataContext.Estudiantes.Add(estudiante);
                await _dataContext.SaveChangesAsync();
                //se poseen tres tipos de created
                // return Created($"/Estudiante/{estudiante.IdEstudiante}", estudiante);
                //return CreatedAtAction(nameof(Get), new {id = estudiante.IdEstudiante, codigo = estudiante.Codigo }, estudiante);
                return CreatedAtRoute("GetEstudiantes", new { id = estudiante.IdEstudiante, codigo = estudiante.Codigo }, estudiante);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Estudiante estudiante)
        {
            if (estudiante.IdEstudiante == 0)
            {
                estudiante.IdEstudiante = id;
            }
            if(estudiante.IdEstudiante != id)
            {
                return BadRequest();
            }

            if (!await _dataContext.Estudiantes.Where(e=>e.IdEstudiante == id).AsNoTracking().AnyAsync())
            {
                return NotFound();
            }

            _dataContext.Entry(estudiante).State= EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

        //[HttpPatch("CambiarCodigo/{id}")]
        //public async Task<IActionResult> CambiarCodigo( int id,[FromQuery] string codigo)
        //{

        //    var 


        //    return
        //}

    }
}
