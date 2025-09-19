using Microsoft.AspNetCore.Mvc;
using CalisteniaAPI.Models; // <-- Importante

namespace CalisteniaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutinasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRutinas()
        {
            var rutinas = new List<Rutina>
            {
                new Rutina { Id = 1, Nombre = "Principiante", Ejercicios = new [] { "Flexiones", "Sentadillas", "Plancha" } },
                new Rutina { Id = 2, Nombre = "Intermedia", Ejercicios = new [] { "Dominadas", "Fondos", "Burpees" } },
                new Rutina { Id = 3, Nombre = "Avanzada", Ejercicios = new [] { "Muscle-ups", "Pistol Squats", "Handstand Push-ups" } }
            };

            return Ok(rutinas);
        }
    }
}
