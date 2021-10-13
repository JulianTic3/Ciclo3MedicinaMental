using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NutricionApp.Dominio

{
  public class Paciente : Persona
  {
    [Required]
    public DateTime FechaNacimiento { get; set; }
    [Required]
    public Genero Genero { get; set; }
    [Required, StringLength(60)]
    public string Direccion { get; set; }
    [Required, StringLength(30)]
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