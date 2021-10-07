using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages.Nutricionistas
{
  public class CrearModel : PageModel
  {
    private readonly IRepositorioNutricionista _RepoNutricionista;
    public Nutricionista Nutricionista { get; set; }
    public CrearModel(IRepositorioNutricionista _RepoNutricionista)
    {
      this._RepoNutricionista = _RepoNutricionista;
    }
    public void OnGet()
    {
      Nutricionista = new Nutricionista();
    }
    public IActionResult OnPost(Nutricionista Nutricionista)
    {
      _RepoNutricionista.AddNutricionista(Nutricionista);
      return RedirectToPage("Lista");
    }
  }
}
