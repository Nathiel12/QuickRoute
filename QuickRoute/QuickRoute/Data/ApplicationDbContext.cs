using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data.Models;
namespace QuickRoute.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Carros> Carros { get; set; }
        public virtual DbSet<Casos> Casos { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Declaraciones> Declaraciones { get; set; }
        public virtual DbSet<Despachos> Despachos { get; set; }
        public virtual DbSet<Impuestos> Impuestos { get; set; }
        public virtual DbSet<Traslados> Traslados { get; set; }
    }
}
