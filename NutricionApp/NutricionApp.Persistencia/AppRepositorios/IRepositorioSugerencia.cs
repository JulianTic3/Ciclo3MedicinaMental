using System;
using System.Collections.Generic;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioSugerencia
  {
    IEnumerable<SugerenciaCuidado> AllSugerencias();
    SugerenciaCuidado AddSugerencia(SugerenciaCuidado SugerenciaCuidado);
    SugerenciaCuidado UpdateSugerencia(SugerenciaCuidado SugerenciaCuidado);
    void DeleteSugerencia(int IdSugerencia);
    SugerenciaCuidado GetSugerencia(int IdSugerencia);
  }
}
