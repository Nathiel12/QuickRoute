using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d{13,19}$", ErrorMessage = "Número de tarjeta inválido (13-19 dígitos)")]
        public string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Formato MM/YY")]
        public string FechaExpiracion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Código de seguridad inválido (3 dígitos)")]
        public string CodigoSeguridad { get; set; }
        public int OrdenId { get; set; }
        public virtual Ordenes Ordenes { get; set; }
    }
}
