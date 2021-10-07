using System;
using System.Collections.Generic;
using NutricionApp.Dominio;
namespace NutricionApp.Persistencia
{
    public interface IRepositorioCoach{
        IEnumerable<Coach> getAllCoachs();
        Coach addCoach(Coach coach);
        Coach getCoach(int idCoach);
        Coach updateCoach(Coach coach);
        void deleteCoach(int idCoach);
    }
}