using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Carros
    {
        [Key]
        public int CarroId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(15, ErrorMessage = "El modelo no puede exceder los 15 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s]+$",
        ErrorMessage = "Solo se permiten letras, números y espacios (sin puntos ni símbolos)")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(typeof(DateTime), "1/1/1886", "1/1/2100", ErrorMessage = "Fecha inválida")]
        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(15, ErrorMessage = "El color no puede exceder los 15 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El color solo puede contener letras y espacios.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(1, 30000000, ErrorMessage = "Debe ser entre $1 y $30,000,000")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, 99, ErrorMessage = "Debe ser entre 1 y 99")]
        public int CantidadStock { get; set; }
        public string ImagenUrl { get; set; } = "/img/carros/default.jpg";
        public bool Disponibilidad { get; set; } = true; 
    }
}
