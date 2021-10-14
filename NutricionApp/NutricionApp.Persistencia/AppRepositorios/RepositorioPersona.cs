using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;
using Microsoft.EntityFrameworkCore;

namespace NutricionApp.Persistencia
{
  public class RepositorioPersona : IRepositorioPersona
  {
    private readonly AppContext _appContext = new AppContext();

    public Persona GetPersona(int cedula)
    {
      return _appContext.Personas.FirstOrDefault(p => p.Identificacion == cedula);
    }
  }
}