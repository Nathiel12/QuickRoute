using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionId { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}
