using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiAlumnos.Entidades;

namespace WebApiAlumnos
{
    public class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Auto> Auto { get; set; }


        public ApplicationDBContext(DbSet<Auto> auto) => Auto = auto;

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }

    }
}
