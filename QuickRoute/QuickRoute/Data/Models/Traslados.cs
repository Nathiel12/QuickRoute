using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Traslados
    {
        [Key]
        public int TrasladoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? Aprobado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public Carros Carro { get; set; }
        public int CarroId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un precio valido")]
        public double Monto { get; set; }
        public string Id { get; set; }

        [ForeignKey("Id")]
        public ApplicationUser Usuario { get; set; }

    }
}
