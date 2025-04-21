using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public string Id { get; set; }
        public DateTime FechaOrden { get; set; } = DateTime.Now;
        public double Total { get; set; }
        public bool Pagada { get; set; } = false;
        public ICollection<OrdenDetalle> Detalles { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}
