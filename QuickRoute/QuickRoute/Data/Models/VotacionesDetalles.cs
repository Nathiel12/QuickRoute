using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class VotacionesDetalles
    {
        [Key]
        public int VotacionDetalleId { get; set; }
        public int TipoVehiculoId { get; set; }

        [ForeignKey("TipoVehiculoId")]
        public TipoVehiculos TipoVehiculo { get; set; } = null!;
        public int VotacionId { get; set; }

        [ForeignKey(nameof(VotacionId))] 
        public Votaciones Votacion { get; set; } = null!;
        public int Puntuacion { get; set; }
    }
}
