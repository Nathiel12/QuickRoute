using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickRoute.Data.Models;

namespace QuickRoute.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Sugerencias> Sugerencias { get; set; }
        public virtual DbSet<Carros> Carros { get; set; }
        public virtual DbSet<Casos> Casos { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Traslados> Traslados { get; set; }
        public virtual DbSet<TrasladosDetalle> TrasladosDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

  
            modelBuilder.Entity<TrasladosDetalle>(entity =>
            {
                entity.HasKey(e => e.DetalleId);

                entity.HasOne(d => d.Traslado)
                    .WithMany(t => t.TrasladosDetalles)
                    .HasForeignKey(d => d.TrasladoId);

                entity.HasOne(d => d.Carro)
                    .WithMany()
                    .HasForeignKey(d => d.CarroId);
            });
        }
    }
}