using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class TipoVehiculos
    {
        [Key]
        public int TipoVehiculoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string VehiculoNombre { get; set; } = null!;
        [Range(1, 10, ErrorMessage = "La cantidad debe de ser entre 1 y 10")]
        [NotMapped]
        public int PuntuacionVoto { get; set; }
        public int PuntuacionTotal { get; set; }
        public double PuntuacionPromedio { get; set; }
        public List<VotacionesDetalles> VotosRecibidos { get; set; } = new List<VotacionesDetalles>();
    }
}
