using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class ListaDeseados
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UsuarioId { get; set; }
        
        [Required]
        public int CarroId { get; set; }
        
        [ForeignKey("CarroId")]
        public virtual Carros Carro { get; set; }
        
        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
    }
}