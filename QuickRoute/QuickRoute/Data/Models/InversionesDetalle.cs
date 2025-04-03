using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class InversionesDetalle
    {
        [Key]
        public int InversionDetalleId { get; set; }
        public int TipoVehiclo { get; set; }

        [Range(0.0000000, double.MaxValue, ErrorMessage = "El monto debe ser positivo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Monto { get; set; }

        [ForeignKey("TipoVehiculoId")] 
        public TipoVehiculos TipoVehiculo { get; set; } = null!;
        public int InversionId { get; set; }

        [ForeignKey(nameof(InversionId))] 
        public Inversiones Inversion { get; set; } = null!;
    }
}
