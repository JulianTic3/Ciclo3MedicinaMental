using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class SugerenciaCuidado
  {
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public string Descripcion { get; set; }
  }
}