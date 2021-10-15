using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class Valoracion
  {
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required, StringLength(4)]
    public float Peso { get; set; }
    [Required, StringLength(4)]
    public float Estatura { get; set; }
    [Required, StringLength(5)]
    public float CaloriasConsumidas { get; set; }
  }
}
