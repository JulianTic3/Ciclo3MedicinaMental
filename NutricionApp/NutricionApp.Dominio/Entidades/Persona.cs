using System;
using System.ComponentModel.DataAnnotations;

namespace NutricionApp.Dominio
{
  public class Persona
  {
    public int Id { get; set; }
    [Required]
    public int Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public string Contrasena { get; set; }
  }
}