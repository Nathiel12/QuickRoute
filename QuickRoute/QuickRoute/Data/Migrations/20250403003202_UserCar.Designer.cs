﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickRoute.Data;

#nullable disable

namespace QuickRoute.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250403003202_UserCar")]
    partial class UserCar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFabricacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroChasis")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<int?>("TrasladoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarroId");

                    b.HasIndex("TrasladoId");

                    b.HasIndex("UsuarioId");

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

                    b.Property<int>("TrasladoId")
                        .HasColumnType("int");

                    b.HasKey("CasoId");

                    b.HasIndex("ContactoId");

                    b.HasIndex("TrasladoId");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactoId");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Declaraciones", b =>
                {
                    b.Property<int>("DeclaracionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeclaracionId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ValorMercancia")
                        .HasColumnType("float");

                    b.Property<double>("ValorTransportacion")
                        .HasColumnType("float");

                    b.HasKey("DeclaracionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Declaraciones");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Despachos", b =>
                {
                    b.Property<int>("SolicitudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolicitudId"));

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int>("DeclaracionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localizacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SolicitudId");

                    b.HasIndex("CarroId")
                        .IsUnique();

                    b.HasIndex("DeclaracionId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Despachos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Impuestos", b =>
                {
                    b.Property<int>("ImpuestoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImpuestoId"));

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ImpuestoId");

                    b.HasIndex("SolicitudId");

                    b.ToTable("Impuestos");

                    b.HasData(
                        new
                        {
                            ImpuestoId = 1,
                            Monto = 0.0,
                            Nombre = "Tasa por Servicio Aduanero",
                            Valor = 0.0
                        },
                        new
                        {
                            ImpuestoId = 2,
                            Monto = 0.0,
                            Nombre = "Arancelarios",
                            Valor = 0.0
                        },
                        new
                        {
                            ImpuestoId = 3,
                            Monto = 0.0,
                            Nombre = "ITBIS",
                            Valor = 0.0
                        },
                        new
                        {
                            ImpuestoId = 4,
                            Monto = 0.0,
                            Nombre = "Declaracion del Valor",
                            Valor = 0.0
                        },
                        new
                        {
                            ImpuestoId = 5,
                            Monto = 0.0,
                            Nombre = "Recargos por Declaracion Tardia",
                            Valor = 0.0
                        },
                        new
                        {
                            ImpuestoId = 6,
                            Monto = 0.0,
                            Nombre = "Declaracion Unica Aduanera",
                            Valor = 0.0
                        });
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.Property<int>("TrasladoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrasladoId"));

                    b.Property<bool>("Aprobado")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("TrasladoId");

                    b.HasIndex("Id");

                    b.ToTable("Traslados");
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
                    b.HasOne("QuickRoute.Data.Models.Traslados", "Traslado")
                        .WithMany("Carros")
                        .HasForeignKey("TrasladoId");

                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Carros")
                        .HasForeignKey("UsuarioId");

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

                    b.HasOne("QuickRoute.Data.Models.Traslados", "Traslado")
                        .WithMany()
                        .HasForeignKey("TrasladoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");

                    b.Navigation("Traslado");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Declaraciones", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Declaraciones")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Despachos", b =>
                {
                    b.HasOne("QuickRoute.Data.Models.Carros", "Carro")
                        .WithOne("Despacho")
                        .HasForeignKey("QuickRoute.Data.Models.Despachos", "CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.Models.Declaraciones", "Declaracion")
                        .WithOne("Despacho")
                        .HasForeignKey("QuickRoute.Data.Models.Despachos", "DeclaracionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Despachos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Carro");

                    b.Navigation("Declaracion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Impuestos", b =>
                {
                    b.HasOne("QuickRoute.Data.Models.Despachos", "Despacho")
                        .WithMany("Impuestos")
                        .HasForeignKey("SolicitudId");

                    b.Navigation("Despacho");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.HasOne("QuickRoute.Data.ApplicationUser", "Usuario")
                        .WithMany("Traslados")
                        .HasForeignKey("Id");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("QuickRoute.Data.ApplicationUser", b =>
                {
                    b.Navigation("Carros");

                    b.Navigation("Declaraciones");

                    b.Navigation("Despachos");

                    b.Navigation("Traslados");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Carros", b =>
                {
                    b.Navigation("Despacho")
                        .IsRequired();
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Declaraciones", b =>
                {
                    b.Navigation("Despacho")
                        .IsRequired();
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Despachos", b =>
                {
                    b.Navigation("Impuestos");
                });

            modelBuilder.Entity("QuickRoute.Data.Models.Traslados", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}
