using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;

namespace NutricionApp.Frontend.Pages
{
  public class CoachModel : PageModel
  {
    private readonly IRepositorioCoach _RepoCoach;
    public IEnumerable<Coach> Coaches { get; set; }

    public CoachModel(IRepositorioCoach _RepoCoach) // metodo constructor
    {
      this._RepoCoach = _RepoCoach;
    }

    public void OnGet()
    {
      // Coaches = _RepoCoach.GetAllCoachs();
    }
  }
}

