using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
