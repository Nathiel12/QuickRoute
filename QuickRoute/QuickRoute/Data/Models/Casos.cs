namespace QuickRoute.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Casos
{
    [Key] 
    public int CasoId { get; set; }

    public int ContactoId { get; set; }
    
    [Required(ErrorMessage = "Por favor, elija un contacto aduanero")]
    public Contactos Contacto { get; set; }
    
    [Required(ErrorMessage = "Por favor, Diga cual es el traslado deseado")]
    public int TrasladoId { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Today;
    
    [Required(ErrorMessage = "Este campo es requerido")] 
    [StringLength(50, ErrorMessage = "El asusnto no puede exceder los 50 caracteres")] 
    public string Asunto { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")] 
    [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")] 
    public string Descripcion { get; set; }

}