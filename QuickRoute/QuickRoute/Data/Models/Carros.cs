using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickRoute.Data.Models
{
    public class Carros
    {
        [Key]
        public int CarroId { get; set; }
        public string Marca { get; set; }

        public string Modelo { get; set; }
        public DateTime FechaFabricacion { get; set; } = DateTime.Now;

        public string Color { get; set; }

        public double Precio { get; set; }
        public string NumeroTitulo { get; set; }
        public int CantidadStock { get; set; }
        public string ImagenUrl { get; set; }
        public bool Disponibilidad { get; set; } = true; 
    }
}
