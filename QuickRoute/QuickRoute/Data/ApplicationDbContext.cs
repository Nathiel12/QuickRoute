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
        public virtual DbSet<Votaciones> Votaciones { get; set; }
        public virtual DbSet<VotacionesDetalles> VotacionesDetalles { get; set; }
        public virtual DbSet<TipoVehiculos> TipoVehiculos { get; set; }

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

            modelBuilder.Entity<TipoVehiculos>().HasData(
            new List<TipoVehiculos>()
            {
                new()
                {
                    TipoVehiculoId = 1,
                    VehiculoNombre = "Moticicleta",
                    PuntuacionVoto = 0,
                },
                new()
                {
                    TipoVehiculoId = 2,
                    VehiculoNombre = "Camión",
                    PuntuacionVoto = 0,
                },
                new()
                {
                    TipoVehiculoId = 3,
                    VehiculoNombre = "Excavadora",
                    PuntuacionVoto = 0,
                },
                new()
                {
                    TipoVehiculoId = 4,
                    VehiculoNombre = "Autobús",
                    PuntuacionVoto = 0,
                },
                new()
                {
                    TipoVehiculoId = 5,
                    VehiculoNombre = "Camión de Remolque",
                    PuntuacionVoto = 0,
                }
            });
        }
    }
}