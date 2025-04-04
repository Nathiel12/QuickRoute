using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Inversiones
    {
        [Key]
        public int InversionId { get; set; }
        public DateTime FechaEncuesta { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 60, ErrorMessage = "El concepto no debe exceder los 60 caracteres")]
        public string Concepto { get; set; }
        public List<InversionesDetalle> InversionesDetalles { get; set; } = new List<InversionesDetalle>();
        public double MontoTotal { get; set; }

    }
}
