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

        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }
        public ICollection<Carros> Carros { get; set; }
    }
}