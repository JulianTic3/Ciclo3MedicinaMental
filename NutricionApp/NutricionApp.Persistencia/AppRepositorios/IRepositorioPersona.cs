using System;
using System.Collections.Generic;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioPersona
  {
    Persona GetPersona(int cedula);
  }
}