using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Declaraciones
    {
        [Key]
        public int DeclaracionId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaEntrega { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un precio valido")]
        public double ValorMercancia { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un precio valido")]
        public double ValorTransportacion { get; set; }
        public int SolicitudId { get; set; }
        public Despachos Despacho { get; set; }
        public string Id { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
