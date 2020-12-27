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
    public class EstudiantesController: ControllerBase
    {
        private readonly DataContext _dataContext;

        public EstudiantesController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async  Task<IEnumerable<Estudiante>> Get()
        {
            return await _dataContext.Estudiantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var estudiante= await _dataContext.Estudiantes.FindAsync(id);

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
                return Created($"/Estudiante/{estudiante.IdEstudiante}", estudiante);
            }

        }
    }
}
