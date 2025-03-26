using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Despachos
    {
        [Key]
        public int SolicitudId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Localizacion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Este campo es requerido")]
        public string NombreEmpresa { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Titulo { get; set; }
        public IList<Impuestos> Impuestos { get; set; } = new List<Impuestos>();
    }
}
