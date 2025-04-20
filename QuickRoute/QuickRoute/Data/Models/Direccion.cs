using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s\-']+$",
        ErrorMessage = "Solo se permiten letras, espacios y guiones.")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Direccion1 { get; set; }
        public string? Direccion2 { get; set; }
        [Required(ErrorMessage = "El código postal es requerido")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Debe tener 5 dígitos numéricos")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Debe tener exactamente 5 dígitos")]
        public string CodigoPostal { get; set; }
        [Required]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}
