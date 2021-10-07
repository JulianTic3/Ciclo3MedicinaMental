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
  public class EliminarModel : PageModel
  {
    private readonly IRepositorioNutricionista _RepoNutricionista;
    public Nutricionista Nutricionista { get; set; }
    public EliminarModel(IRepositorioNutricionista _RepoNutricionista)
    {
      this._RepoNutricionista = _RepoNutricionista;
    }
    public IActionResult OnGet(int Id)
    {
      Nutricionista = _RepoNutricionista.GetNutricionista(Id);
      if (Nutricionista == null)
      {
        return NotFound();
      }
      else { return Page(); }
    }
    public IActionResult OnPost(int Id)
    {
      _RepoNutricionista.DeleteNutricionista(Id);
      return RedirectToPage("Lista");
    }
  }
}
