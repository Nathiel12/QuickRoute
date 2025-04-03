using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Traslados
    {
        [Key]
        public int TrasladoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? Aprobado { get; set; }

        public List<TrasladosDetalle> TrasladosDetalles { get; set; } = new List<TrasladosDetalle>();

        public string Id { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }
    }
}