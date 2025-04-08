using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Traslados
    {
        [Key]
        public int TrasladoId { get; set; }

        public List<TrasladosDetalle> TrasladosDetalles { get; set; } = new List<TrasladosDetalle>();

        public string Id { get; set; }

        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "Los nombrse solo pueden contener letras y espacios")]
        [StringLength(maximumLength: 50, ErrorMessage = "Los nombres no pueden exceder los 50 caracteres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 60, ErrorMessage = "La dirección no debe exceder los 60 caracteres")]
        public string Direccion { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }
        public ICollection<Carros> Carros { get; set; }
    }
}