using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(85, ErrorMessage = "El nombre no puede exceder 85 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$",
        ErrorMessage = "Solo letras y espacios (sin números ni símbolos)")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d{13,19}$", ErrorMessage = "Número de tarjeta inválido (13-19 dígitos)")]
        [CreditCard]
        public string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Formato MM/YY")]
        public string FechaExpiracion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Código de seguridad inválido (3 dígitos)")]
        public string CodigoSeguridad { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int? DireccionId { get; set; }  
        [ForeignKey("DireccionId")]
        public virtual Direccion Direccion { get; set; }
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public virtual Ordenes Ordenes { get; set; }
    }
}
