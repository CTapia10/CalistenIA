using Microsoft.AspNetCore.Mvc;
using CalisteniaAPI.Services;

namespace CalisteniaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly OllamaService _ollama;

        public ChatController(OllamaService ollama)
        {
            _ollama = ollama;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var respuesta = await _ollama.EnviarMensajeAsync(request.Pregunta);
            return Ok(new { respuesta });
        }
    }

    public class ChatRequest
    {
        public string Pregunta { get; set; } = string.Empty;
    }
}
