﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Carros
    {
        [Key]
        public int CarroId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(15, ErrorMessage = "La marca no puede exceder los 15 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La marca solo puede contener letras y espacios")]
        public string Marca { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(15, ErrorMessage = "El modelo no puede exceder los 15 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s]+$",
        ErrorMessage = "Solo se permiten letras, números y espacios (sin puntos ni símbolos)")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2100", ErrorMessage = "Fecha inválida")]
        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(15, ErrorMessage = "El color no puede exceder los 15 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El color solo puede contener letras y espacios.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(1, 5000000, ErrorMessage = "Debe ser entre $1 y $5,000,000")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El número de título es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El número de título debe tener exactamente 17 caracteres.")]
        [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "El número de título contiene caracteres inválidos. (No debe contener I u O")]
        public string NumeroTitulo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public bool Aprobado { get; set; } = false;
        public bool EnTraslado { get; set; } = false;
        public int? TrasladoId { get; set; }
        public Traslados? Traslado { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }
        [NotMapped] 
        public double MontoAcumuladoTraslados { get; set; }
    }
}
