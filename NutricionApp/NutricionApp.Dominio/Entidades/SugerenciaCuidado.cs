using System;
namespace NutricionApp.Dominio
{
  public class SugerenciaCuidado
  {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public Historia Historia { get; set; }
    public Nutricionista Nutricionista { get; set; }
  }
}