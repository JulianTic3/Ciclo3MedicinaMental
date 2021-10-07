using System;
using System.Collections.Generic;
using NutricionApp.Dominio;
using Microsoft.EntityFrameworkCore;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioNutricionista
  {
    IEnumerable<Nutricionista> AllNutricionistas();
    Nutricionista AddNutricionista(Nutricionista nutricionista);
    Nutricionista UpdateNutricionista(Nutricionista nutricionista);
    void DeleteNutricionista(int IdNutricionista);
    Nutricionista GetNutricionista(int IdNutricionista);
  }
}
