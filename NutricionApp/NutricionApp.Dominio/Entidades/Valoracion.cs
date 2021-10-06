using System;
namespace NutricionApp.Dominio
{
  public class Valoracion
  {
    public int Id {get;set;}
    public DateTime Fecha { get; set; }
    public float Peso { get; set; }
    public float Estatura { get; set; }
    public float CaloriasConsumidas { get; set; }
    public Historia Historia { get; set; }
  }
}