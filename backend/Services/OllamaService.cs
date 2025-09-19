using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace CalisteniaAPI.Services
{
    public class OllamaService
    {
        private readonly OllamaApiClient _client;
        private readonly List<Message> _historial;

        public OllamaService()
        {
            var uri = new Uri("http://localhost:11434");
            _client = new OllamaApiClient(uri);
            _client.SelectedModel = "llama3"; // Cambiá el modelo según lo que uses

            _historial = new List<Message>();
        }

        public async Task<string> EnviarMensajeAsync(string pregunta)
        {
            // Agregar mensaje del usuario
            _historial.Add(new Message("user", pregunta));

            // Crear request con el historial
            var request = new ChatRequest
            {
                Model = _client.SelectedModel,
                Messages = _historial
            };

            // ChatAsync devuelve un stream de respuestas
            var respuestaStream = _client.ChatAsync(request);

            string texto = "";

            await foreach (var respuesta in respuestaStream)
            {
                if (respuesta?.Message?.Content != null)
                {
                    texto += respuesta.Message.Content;
                }
            }

            // Guardar respuesta completa en el historial
            _historial.Add(new Message("assistant", texto));

            return texto;
        }

    }
}
