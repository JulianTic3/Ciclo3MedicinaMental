using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public class RepositorioSugerencia : IRepositorioSugerencia
  {
    private readonly AppContext _appContext = new AppContext();
    public SugerenciaCuidado AddSugerencia(SugerenciaCuidado SugerenciaCuidado)
    {
      var SugerenciaAdicionado = _appContext.SugerenciasCuidados.Add(SugerenciaCuidado);
      _appContext.SaveChanges();
      return SugerenciaAdicionado.Entity;
    }

    public IEnumerable<SugerenciaCuidado> AllSugerencias()
    {
      return _appContext.SugerenciasCuidados;
    }

    public void DeleteSugerencia(int IdSugerencia)
    {
      var SugerenciaEncontrado = _appContext.SugerenciasCuidados.FirstOrDefault(p => p.Id == IdSugerencia);
      if (SugerenciaEncontrado == null)
        return;
      _appContext.SugerenciasCuidados.Remove(SugerenciaEncontrado);
      _appContext.SaveChanges();
    }

    public SugerenciaCuidado GetSugerencia(int IdSugerencia)
    {
      return _appContext.SugerenciasCuidados.FirstOrDefault(p => p.Id == IdSugerencia);
    }

    public SugerenciaCuidado UpdateSugerencia(SugerenciaCuidado SugerenciaCuidado)
    {
      var SugerenciaEncontrado = _appContext.SugerenciasCuidados.FirstOrDefault(p => p.Id == SugerenciaCuidado.Id);
      if (SugerenciaEncontrado != null)
      {
        SugerenciaEncontrado.Id = SugerenciaCuidado.Id;
        SugerenciaEncontrado.Fecha = SugerenciaCuidado.Fecha;
        SugerenciaEncontrado.Descripcion = SugerenciaCuidado.Descripcion;
        SugerenciaEncontrado.Historia = SugerenciaCuidado.Historia;
        SugerenciaEncontrado.Nutricionista = SugerenciaCuidado.Nutricionista;

        _appContext.SaveChanges();
      }
      return SugerenciaEncontrado;
    }
  }
}