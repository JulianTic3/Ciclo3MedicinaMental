using System;
using System.Collections.Generic;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioCoach
  {
    IEnumerable<Coach> GetAllCoachs();
    Coach AddCoach(Coach coach);
    Coach GetCoach(int idCoach);
    Coach UpdateCoach(Coach coach);
    void DeleteCoach(int idCoach);
  }
}