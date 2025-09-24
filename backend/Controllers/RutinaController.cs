using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalistenIA.Models;

namespace CalisteniaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutinasController : ControllerBase
    {
        private readonly CalisteniaContext _context;

        public RutinasController(CalisteniaContext context)
        {
            _context = context;
        }

        // GET: api/rutinas
        [HttpGet]
        public async Task<IActionResult> GetRutinas()
        {
            // Incluye los ejercicios relacionados
            var rutinas = await _context.Rutinas
                .Include(r => r.Ejercicios)
                .ToListAsync();

            return Ok(rutinas);
        }

        // POST: api/rutinas
        [HttpPost]
        public async Task<IActionResult> CrearRutina(Rutina rutina)
        {
            _context.Rutinas.Add(rutina);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRutinas), new { id = rutina.Id }, rutina);
        }
    }
}
