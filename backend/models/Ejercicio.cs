namespace CalistenIA.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }
    }
}