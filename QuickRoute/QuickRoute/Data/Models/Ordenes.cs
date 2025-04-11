using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Ordenes
    {
        public int OrdenId { get; set; }
        public string Id { get; set; }
        public DateTime FechaOrden { get; set; } = DateTime.Now;
        public double Total { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public ICollection<OrdenDetalle> Detalles { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}
