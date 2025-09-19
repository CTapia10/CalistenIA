using OllamaSharp;

namespace CalisteniaAPI.Services
{
    public class OllamaService
    {
        private readonly OllamaApiClient _client;

        public OllamaService()
        {
            // Por defecto Ollama corre en http://localhost:11434
            var uri = new Uri("http://localhost:11434");
            _client = new OllamaApiClient(uri);
        }

        public async Task<string> ObtenerRespuestaAsync(string pregunta, string modelo = "llama3")
        {
            // Cambiá "llama3" por el modelo que tengas cargado en Ollama
            _client.SelectedModel = modelo;

            var respuesta = await _client.GetCompletion(pregunta);

            return respuesta?.Response ?? "No se obtuvo respuesta del modelo.";
        }
    }
}
