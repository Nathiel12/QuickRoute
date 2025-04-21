using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Votaciones
    {
        [Key]
        public int VotacionId { get; set; }
        public DateTime FechaEncuesta { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Este campo es requerido")]
        public List<VotacionesDetalles> VotacionesDetalle { get; set; } = new List<VotacionesDetalles>();
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }
    }
}
