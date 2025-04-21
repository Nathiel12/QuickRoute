using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }
        public string Id { get; set; } 
        public int CarroId { get; set; }
        [Range(1, 10, ErrorMessage = "La cantidad debe de ser entre 1 y 10.")]
        public int Cantidad { get; set; } = 1;
        public DateTime FechaAgregado { get; set; } = DateTime.Now;
        
        [ForeignKey("CarroId")]
        public virtual Carros Carro { get; set; }
        
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}