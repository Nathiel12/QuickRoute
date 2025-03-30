using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Phone]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CasoId { get; set; }
    }
}
