using System;
using System.Collections.Generic;
namespace NutricionApp.Dominio

{
  public class Paciente : Persona
  {
    public DateTime FechaNacimiento { get; set; }
    public Genero Genero { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public float Latitud { get; set; }
    public float Longitud { get; set; }
    public Nutricionista Nutricionista { get; set; }
    public Coach Coach { get; set; }
    public Historia Historia { get; set; }
    public List<SugerenciaCuidado> SugerenciasCuidados { get; set; }
    public List<Valoracion> Valoraciones { get; set; }
  }
}