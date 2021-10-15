using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class Historia
  {
    public int Id { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [Required]
    public string Diagnostico { get; set; }
  }
}