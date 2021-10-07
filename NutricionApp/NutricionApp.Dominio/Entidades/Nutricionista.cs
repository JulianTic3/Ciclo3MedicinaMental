using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class Nutricionista : Persona
  {
    [Required, StringLength(15)]
    public string TarjetaProfesional { get; set; }
  }
}