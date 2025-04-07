﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickRoute.Data;

#nullable disable

namespace QuickRoute.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuickRoute.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Carros", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"));

                    b.Property<bool>("Aprobado")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("EnTraslado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFabricacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NumeroTitulo")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int?>("TrasladoId")
                        .HasColumnType("int");

                    b.HasKey("CarroId");

                    b.HasIndex("Id");

                    b.HasIndex("TrasladoId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Casos", b =>
                {
                    b.Property<int>("CasoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CasoId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("CasoId");

                    b.HasIndex("ContactoId");

                    b.ToTable("Casos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Contactos", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactoId"));

                    b.Property<int>("CasoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ContactoId");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Sugerencias", b =>
                {
                    b.Property<int>("SugerenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SugerenciaId"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("satisfaccion")
                        .HasColumnType("int");

                    b.HasKey("SugerenciaId");

                    b.ToTable("Sugerencias");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.TipoVehiculos", b =>
                {
                    b.Property<int>("TipoVehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoVehiculoId"));

                    b.Property<double>("PuntuacionPromedio")
                        .HasColumnType("float");

                    b.Property<int>("PuntuacionTotal")
                        .HasColumnType("int");

                    b.Property<string>("VehiculoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoVehiculoId");

                    b.ToTable("TipoVehiculos");

                    b.HasData(
                        new
                        {
                            TipoVehiculoId = 1,
                            PuntuacionPromedio = 0.0,
                            PuntuacionTotal = 0,
                            VehiculoNombre = "Moticicleta"
                        },
                        new
                        {
                            TipoVehiculoId = 2,
                            PuntuacionPromedio = 0.0,
                            PuntuacionTotal = 0,
                            VehiculoNombre = "Camión"
                        },
                        new
                        {
                            TipoVehiculoId = 3,
                            PuntuacionPromedio = 0.0,
                            PuntuacionTotal = 0,
                            VehiculoNombre = "Excavadora"
                        },
                        new
                        {
                            TipoVehiculoId = 4,
                            PuntuacionPromedio = 0.0,
                            PuntuacionTotal = 0,
                            VehiculoNombre = "Autobús"
                        },
                        new
                        {
                            TipoVehiculoId = 5,
                            PuntuacionPromedio = 0.0,
                            PuntuacionTotal = 0,
                            VehiculoNombre = "Camión de Remolque"
                        });
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.Property<int>("TrasladoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrasladoId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TrasladoId");

                    b.HasIndex("Id");

                    b.ToTable("Traslados");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.TrasladosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("TrasladoId")
                        .HasColumnType("int");

                    b.HasKey("DetalleId");

                    b.HasIndex("CarroId");

                    b.HasIndex("TrasladoId");

                    b.ToTable("TrasladosDetalles");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Votaciones", b =>
                {
                    b.Property<int>("VotacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VotacionId"));

                    b.Property<DateTime>("FechaEncuesta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VotacionId");

                    b.HasIndex("Id");

                    b.ToTable("Votaciones");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.VotacionesDetalles", b =>
                {
                    b.Property<int>("VotacionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VotacionDetalleId"));

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<int>("VotacionId")
                        .HasColumnType("int");

                    b.HasKey("VotacionDetalleId");

                    b.HasIndex("TipoVehiculoId");

                    b.HasIndex("VotacionId");

                    b.ToTable("VotacionesDetalles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Carros", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Carros")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.Models.Traslados", "Traslado")
                        .WithMany("Carros")
                        .HasForeignKey("TrasladoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Traslado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Casos", b =>
                {
                    b.HasOne("QuickRoute.Data.Models.Contactos", "Contacto")
                        .WithMany()
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Traslados")
                        .HasForeignKey("Id");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.TrasladosDetalle", b =>
                {
                    b.HasOne("QuickRoute.Data.Models.Carros", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.Models.Traslados", "Traslado")
                        .WithMany("TrasladosDetalles")
                        .HasForeignKey("TrasladoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Traslado");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Votaciones", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.VotacionesDetalles", b =>
                {
                    b.HasOne("QuickRoute.Data.Models.TipoVehiculos", "TipoVehiculo")
                        .WithMany("VotosRecibidos")
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.Models.Votaciones", "Votacion")
                        .WithMany("VotacionesDetalle")
                        .HasForeignKey("VotacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVehiculo");

                    b.Navigation("Votacion");
                });

            modelBuilder.Entity("QuickRoute.Data.ApplicationUser", b =>
                {
                    b.Navigation("Carros");

                    b.Navigation("Traslados");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.TipoVehiculos", b =>
                {
                    b.Navigation("VotosRecibidos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.Navigation("Carros");

                    b.Navigation("TrasladosDetalles");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Votaciones", b =>
                {
                    b.Navigation("VotacionesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
