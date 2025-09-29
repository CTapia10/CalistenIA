namespace CalistenIA.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dificultad { get; set; }
        public List<Ejercicio> Ejercicios { get; set; } = [];
        public int DuracionMinutos { get; set; }
        public string Descripcion { get; set; }





    }
}
