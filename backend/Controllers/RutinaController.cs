using Microsoft.AspNetCore.Mvc;
using CalistenIA.Models; // Asegurate que este namespace coincide con tu proyecto
using CalistenIA.Data;
using System.Linq;

namespace CalistenIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinasController : ControllerBase
    {
        private readonly CalisteniaContext _context;

        public RutinasController(CalisteniaContext context)
        {
            _context = context;
        }

        // GET: api/rutinas
        [HttpGet]
        public IActionResult GetRutinas()
        {
            var rutinas = _context.Rutinas.ToList();
            return Ok(rutinas);
        }

        // GET: api/rutinas/5
        [HttpGet("{id}")]
        public IActionResult GetRutina(int id)
        {
            var rutina = _context.Rutinas.Find(id);
            if (rutina == null)
                return NotFound();

            return Ok(rutina);
        }

        // POST: api/rutinas
        [HttpPost]
        public IActionResult CrearRutina([FromBody] Rutina nuevaRutina)
        {
            _context.Rutinas.Add(nuevaRutina);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRutina), new { id = nuevaRutina.Id }, nuevaRutina);
        }

        // PUT: api/rutinas/5
        [HttpPut("{id}")]
        public IActionResult ActualizarRutina(int id, [FromBody] Rutina rutinaActualizada)
        {
            var rutina = _context.Rutinas.Find(id);
            if (rutina == null)
                return NotFound();

            rutina.Nombre = rutinaActualizada.Nombre;
            rutina.Descripcion = rutinaActualizada.Descripcion;
            rutina.DuracionMinutos = rutinaActualizada.DuracionMinutos;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/rutinas/5
        [HttpDelete("{id}")]
        public IActionResult EliminarRutina(int id)
        {
            var rutina = _context.Rutinas.Find(id);
            if (rutina == null)
                return NotFound();

            _context.Rutinas.Remove(rutina);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
