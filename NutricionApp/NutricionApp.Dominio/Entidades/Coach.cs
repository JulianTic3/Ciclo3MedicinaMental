using System;
using System.ComponentModel.DataAnnotations;
namespace NutricionApp.Dominio
{
  public class Coach : Persona
  {
    [Required, StringLength(40)]
    public string Especialidad { get; set; }
    [Required, StringLength(15)]
    public string NumeroCertificacion { get; set; }
  }
}