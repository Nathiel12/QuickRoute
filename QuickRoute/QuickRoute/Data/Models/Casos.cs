namespace QuickRoute.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Casos
{
    [Key]
    public int CasoId { get; set; }

    [Required(ErrorMessage = "Por favor, elija un contacto aduanero")]
    public int ContactoId { get; set; }  

    [ForeignKey("ContactoId")]
    public Contactos? Contacto { get; set; }  

    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(50, ErrorMessage = "El asunto no puede exceder los 50 caracteres")]
    public string Asunto { get; set; } = string.Empty;  

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")]
    public string Descripcion { get; set; } = string.Empty;
    public string Id { get; set; }
    [ForeignKey("Id")]
    public ApplicationUser Usuario { get; set; }
}