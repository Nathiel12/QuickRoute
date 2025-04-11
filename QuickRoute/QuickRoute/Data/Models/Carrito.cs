using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public string Id { get; set; } 
        public int CarroId { get; set; }     
        public int Cantidad { get; set; } = 1;
        public DateTime FechaAgregado { get; set; } = DateTime.Now;
        public virtual Carros Carro { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser Usuario { get; set; }
    }
}
