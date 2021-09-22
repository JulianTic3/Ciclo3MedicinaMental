using System;
namespace NutricionApp.Dominio
{
  public class Paciente : Persona
  {
    public DateTime FechaNacimiento { get; set; }
    public string Genero { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public float Latitud { get; set; }
    public float Longitud { get; set; }
    public Nutricionista Nutricionista { get; set; }
    public Coach Coach { get; set; }
  }
}