using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public class RepositorioNutricionista : IRepositorioNutricionista
  {
    private readonly AppContext _appContext;
    public RepositorioNutricionista(AppContext appContext)
    {
      _appContext = appContext;
    }
    public Nutricionista AddNutricionista(Nutricionista Nutricionista)
    {
      var NutricionistaAdicionado = _appContext.Nutricionistas.Add(Nutricionista);
      _appContext.SaveChanges();
      return NutricionistaAdicionado.Entity;
    }

    public IEnumerable<Nutricionista> AllNutricionistas()
    {
      return _appContext.Nutricionistas;
    }

    public void DeleteNutricionista(int IdNutricionista)
    {
      var NutricionistaEncontrado = _appContext.Nutricionistas.FirstOrDefault(p => p.Id == IdNutricionista);
      if (NutricionistaEncontrado == null)
        return;
      _appContext.Nutricionistas.Remove(NutricionistaEncontrado);
      _appContext.SaveChanges();
    }

    public Nutricionista GetNutricionista(int IdNutricionista)
    {
      return _appContext.Nutricionistas.FirstOrDefault(p => p.Id == IdNutricionista);
    }

    public Nutricionista UpdateNutricionista(Nutricionista Nutricionista)
    {
      var NutricionistaEncontrado = _appContext.Nutricionistas.FirstOrDefault(p => p.Id == Nutricionista.Id);
      if (NutricionistaEncontrado != null)
      {
        NutricionistaEncontrado.Id = Nutricionista.Id;
        NutricionistaEncontrado.Nombre = Nutricionista.Nombre;
        NutricionistaEncontrado.Apellidos = Nutricionista.Apellidos;
        NutricionistaEncontrado.Identificacion = Nutricionista.Identificacion;
        NutricionistaEncontrado.Correo = Nutricionista.Correo;
        NutricionistaEncontrado.Contrasena = Nutricionista.Contrasena;
        NutricionistaEncontrado.Telefono = Nutricionista.Telefono;
        NutricionistaEncontrado.TarjetaProfesional = Nutricionista.TarjetaProfesional;
        _appContext.SaveChanges();
      }
      return NutricionistaEncontrado;
    }
  }
}
