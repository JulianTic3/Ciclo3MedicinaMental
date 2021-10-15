using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class Valoracion
  {
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public float Peso { get; set; }
    [Required]
    public float Estatura { get; set; }
    [Required]
    public float CaloriasConsumidas { get; set; }
  }
}
