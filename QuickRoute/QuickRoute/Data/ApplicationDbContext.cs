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
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }

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
            modelBuilder.Entity<Carros>().HasData(
            new List<Carros>()
            {
                new()
                {
                    CarroId = 1,
                    Marca = "Honda",
                    Modelo = "Civic",
                    Color = "Azul",
                    Precio = 24250,
                    CantidadStock = 10,
                    FechaFabricacion = new DateTime(2011, 4, 20)
                },
                new()
                {
                    CarroId = 2,
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    Color = "Rojo",
                    Precio = 22325,
                    CantidadStock = 5,
                    FechaFabricacion = new DateTime(2014, 6, 19)
                },
                new()
                {
                    CarroId = 3,
                    Marca = "Toyota",
                    Modelo = "Camry",
                    Color = "Blanco",
                    Precio = 29795,
                    CantidadStock = 6,
                    FechaFabricacion = new DateTime(2018, 12, 11)
                },
                new()
                {
                    CarroId = 4,
                    Marca = "Audi",
                    Modelo = "a4",
                    Color = "Negro",
                    Precio = 44100,
                    CantidadStock = 9,
                    FechaFabricacion = new DateTime(2015, 09, 4)
                },
                new()
                {
                    CarroId = 5,
                    Marca = "BMW",
                    Modelo = "m4",
                    Color = "Amarillo",
                    Precio = 80875,
                    CantidadStock = 7,
                    FechaFabricacion = new DateTime(2016, 01, 07)
                }
            });
        }
    }
}