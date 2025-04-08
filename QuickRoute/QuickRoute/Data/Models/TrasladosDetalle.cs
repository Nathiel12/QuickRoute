using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class TrasladosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CarroId { get; set; }

        [Range(0.0000000, 5000000, ErrorMessage = "El monto debe ser positivo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Monto { get; set; }

        [ForeignKey("CarroId")]
        public Carros Carro { get; set; } = null!;

        public int TrasladoId { get; set; }

        [ForeignKey(nameof(TrasladoId))]
        public Traslados Traslado { get; set; } = null!;
    }
}