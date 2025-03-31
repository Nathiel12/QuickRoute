using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Impuestos
    {
        [Key]
        public int ImpuestoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un precio valido")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")] // No se almacena en la BD, se calcula dinámicamente
        public double Valor { get; set; }

        public int SolicitudId { get; set; }
        [ForeignKey("SolicitudId")]
        public Despachos Despacho { get; set; }
    }
}
