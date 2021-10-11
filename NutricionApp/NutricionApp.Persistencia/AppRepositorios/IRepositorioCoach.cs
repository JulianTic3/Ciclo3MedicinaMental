using System;
using System.Collections.Generic;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioCoach
  {
    IEnumerable<Coach> GetAllCoach();
    Coach AddCoach(Coach coach);
    Coach GetCoach(int IdCoach);
    Coach UpdateCoach(Coach coach);
    void DeleteCoach(int IdCoach);
  }
}