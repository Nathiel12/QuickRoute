using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class TipoVehiculos
    {
        [Key]
        public int TipoVehiculoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string VehiculoNombre { get; set; } = null!;
        [Range(0.0000000, Double.MaxValue, ErrorMessage = "El monto debe ser positivo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Monto { get; set; }
    }
}
