using System.ComponentModel.DataAnnotations;

namespace QuickRoute.Data.Models
{
    public class Despachos
    {
        [Key]
        public int SolicitudId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(255, ErrorMessage = "La localización no puede superar los 255 caracteres")]
        public string Localizacion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "La fecha debe estar entre 01/01/1900 y 01/01/2100")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(200, ErrorMessage = "El nombre de la empresa no puede superar los 200 caracteres")]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres")]
        public string Titulo { get; set; }

        public int CarroId { get; set; }
        public Carros Carro { get; set; }

        public ICollection<Impuestos> Impuestos { get; set; } = new List<Impuestos>();
        public int DeclaracionId { get; set; }
        public Declaraciones Declaracion { get; set; }
        public string Id { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
