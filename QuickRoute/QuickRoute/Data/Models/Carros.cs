using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Carros
    {
        [Key]
        public int CarroId { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La marca solo puede contener letras y espacios")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage ="Ingrese un precio valido")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El número de chasis es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El número de chasis debe tener exactamente 17 caracteres.")]
        [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "El número de chasis contiene caracteres inválidos. (No debe contener I u O")]
        public string NumeroChasis { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public byte[] Factura { get; set; }
    }
}
