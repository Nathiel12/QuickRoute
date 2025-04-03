namespace QuickRoute.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sugerencias
{
    [Key]
    public int SugerenciaId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(50, ErrorMessage = "El asusnto no puede exceder los 50 caracteres")]
    public string Asunto { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")]
    public string Descripcion { get; set; }

    [Range(1,5)]
    [Required(ErrorMessage = "Por favor Seleccione su nivel de satisfacción")]
    public int satisfaccion { get; set; }
}