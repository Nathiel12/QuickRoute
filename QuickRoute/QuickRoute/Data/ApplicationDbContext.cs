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
            Marca = "Honda",
            Modelo = "Civic",
            Color = "Rojo",
            Precio = 25800,
            CantidadStock = 15,
            FechaFabricacion = new DateTime(2011, 4, 20)
        },
        new()
        {
            CarroId = 3,
            Marca = "Toyota",
            Modelo = "Corolla",
            Color = "Rojo",
            Precio = 22325,
            CantidadStock = 5,
            FechaFabricacion = new DateTime(2014, 6, 19)
        },
        new()
        {
            CarroId = 4,
            Marca = "Toyota",
            Modelo = "Camry",
            Color = "Blanco",
            Precio = 29795,
            CantidadStock = 6,
            FechaFabricacion = new DateTime(2018, 12, 11)
        },
        new()
        {
            CarroId = 5,
            Marca = "Audi",
            Modelo = "a4",
            Color = "Negro",
            Precio = 44100,
            CantidadStock = 9,
            FechaFabricacion = new DateTime(2015, 09, 4)
        },
        new()
        {
            CarroId = 6,
            Marca = "BMW",
            Modelo = "m4",
            Color = "Amarillo",
            Precio = 80875,
            CantidadStock = 7,
            FechaFabricacion = new DateTime(2016, 01, 07)
        },
        new()
        {
            CarroId = 7,
            Marca = "Ford",
            Modelo = "Mustang",
            Color = "Rojo",
            Precio = 42865,
            CantidadStock = 8,
            FechaFabricacion = new DateTime(2020, 3, 15)
        },
        new()
        {
            CarroId = 8,
            Marca = "Chevrolet",
            Modelo = "Camaro",
            Color = "Negro",
            Precio = 37695,
            CantidadStock = 5,
            FechaFabricacion = new DateTime(2019, 7, 22)
        },
        new()
        {
            CarroId = 9,
            Marca = "Volkswagen",
            Modelo = "Golf",
            Color = "Blanco",
            Precio = 23995,
            CantidadStock = 12,
            FechaFabricacion = new DateTime(2017, 5, 10)
        },
        new()
        {
            CarroId = 10,
            Marca = "Mercedes-Benz",
            Modelo = "C-Class",
            Color = "Plateado",
            Precio = 55150,
            CantidadStock = 6,
            FechaFabricacion = new DateTime(2018, 9, 5)
        },
        new()
        {
            CarroId = 11,
            Marca = "Nissan",
            Modelo = "Sentra",
            Color = "Gris",
            Precio = 21510,
            CantidadStock = 9,
            FechaFabricacion = new DateTime(2021, 2, 18)
        },
        new()
        {
            CarroId = 12,
            Marca = "Hyundai",
            Modelo = "Tucson",
            Color = "Azul Marino",
            Precio = 27650,
            CantidadStock = 7,
            FechaFabricacion = new DateTime(2020, 11, 30)
        },
        new()
        {
            CarroId = 13,
            Marca = "Kia",
            Modelo = "Sportage",
            Color = "Verde",
            Precio = 26490,
            CantidadStock = 4,
            FechaFabricacion = new DateTime(2019, 4, 25)
        },
        new()
        {
            CarroId = 14,
            Marca = "Subaru",
            Modelo = "Outback",
            Color = "Marrón",
            Precio = 31995,
            CantidadStock = 5,
            FechaFabricacion = new DateTime(2021, 1, 12)
        },
        new()
        {
            CarroId = 15,
            Marca = "Mazda",
            Modelo = "CX-5",
            Color = "Rojo Carmesí",
            Precio = 29185,
            CantidadStock = 8,
            FechaFabricacion = new DateTime(2020, 8, 7)
        },
        new()
        {
            CarroId = 16,
            Marca = "Jeep",
            Modelo = "Wrangler",
            Color = "Amarillo",
            Precio = 39995,
            CantidadStock = 3,
            FechaFabricacion = new DateTime(2022, 3, 3)
        },
        new()
        {
            CarroId = 17,
            Marca = "Tesla",
            Modelo = "Model 3",
            Color = "Blanco",
            Precio = 46990,
            CantidadStock = 6,
            FechaFabricacion = new DateTime(2021, 10, 15)
        },
        new()
        {
            CarroId = 18,
            Marca = "Lexus",
            Modelo = "RX 350",
            Color = "Gris Perla",
            Precio = 51275,
            CantidadStock = 4,
            FechaFabricacion = new DateTime(2019, 12, 20)
        },
        new()
        {
            CarroId = 19,
            Marca = "Porsche",
            Modelo = "911",
            Color = "Negro",
            Precio = 113200,
            CantidadStock = 2,
            FechaFabricacion = new DateTime(2020, 5, 17)
        },
        new()
        {
            CarroId = 20,
            Marca = "Land Rover",
            Modelo = "Range Rover",
            Color = "Plateado",
            Precio = 98500,
            CantidadStock = 3,
            FechaFabricacion = new DateTime(2018, 7, 10)
        },
        new()
        {
            CarroId = 21,
            Marca = "Volvo",
            Modelo = "XC60",
            Color = "Azul Oscuro",
            Precio = 45950,
            CantidadStock = 5,
            FechaFabricacion = new DateTime(2021, 6, 8)
        },
        new()
        {
            CarroId = 22,
            Marca = "Ferrari",
            Modelo = "488 GTB",
            Color = "Rojo",
            Precio = 335000,
            CantidadStock = 1,
            FechaFabricacion = new DateTime(2022, 2, 14)
        },
        new()
        {
            CarroId = 23,
            Marca = "Lamborghini",
            Modelo = "Huracán",
            Color = "Amarillo",
            Precio = 261274,
            CantidadStock = 1,
            FechaFabricacion = new DateTime(2021, 9, 9)
        },
        new()
        {
            CarroId = 24,
            Marca = "Mitsubishi",
            Modelo = "Outlander",
            Color = "Gris Plata",
            Precio = 28795,
            CantidadStock = 7,
            FechaFabricacion = new DateTime(2020, 4, 22)
        },
        new()
        {
            CarroId = 25,
            Marca = "Dodge",
            Modelo = "Charger",
            Color = "Negro",
            Precio = 36665,
            CantidadStock = 4,
            FechaFabricacion = new DateTime(2019, 11, 5)
        }
    });
        }
    }
}