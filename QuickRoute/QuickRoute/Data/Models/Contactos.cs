using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Phone]
        [StringLength(10, ErrorMessage = "El telefono no puede exceder los 10 caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        [StringLength(32, ErrorMessage = "El email no puede exceder los 32 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CasoId { get; set; }
    }
}
