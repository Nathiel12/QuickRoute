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
            modelBuilder.Entity<Carros>()
            .HasOne(c => c.Traslado)          
            .WithMany(t => t.Carros)         
            .HasForeignKey(c => c.TrasladoId) 
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Carros)           // Un usuario tiene muchos carros
            .WithOne(c => c.Usuario)           // Un carro pertenece a un usuario
            .HasForeignKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Impuestos>().HasData(
                new Impuestos { ImpuestoId = 1, Nombre = "Tasa por Servicio Aduanero", Monto = 0 },
                new Impuestos { ImpuestoId = 2, Nombre = "Arancelarios", Monto = 0 },
                new Impuestos { ImpuestoId = 3, Nombre = "ITBIS", Monto = 0 },
                new Impuestos { ImpuestoId = 4, Nombre = "Declaracion del Valor", Monto = 0 },
                new Impuestos { ImpuestoId = 5, Nombre = "Recargos por Declaracion Tardia", Monto = 0 },
                new Impuestos { ImpuestoId = 6, Nombre = "Declaracion Unica Aduanera", Monto = 0 }
            );
        }
    }
}