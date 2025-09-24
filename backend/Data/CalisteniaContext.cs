using CalistenIA.Models;
using Microsoft.EntityFrameworkCore;

namespace CalistenIA.Data
{
    public class CalisteniaContext : DbContext
    {
        public CalisteniaContext(DbContextOptions<CalisteniaContext> options)
            : base(options) { }

        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
    }
}
