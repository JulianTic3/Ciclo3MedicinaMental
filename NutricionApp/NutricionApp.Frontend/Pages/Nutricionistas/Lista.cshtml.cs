using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;

namespace NutricionApp.Frontend.Pages.Nutricionistas
{
  public class ListaModel : PageModel
  {
    private readonly IRepositorioNutricionista _RepoNutricionista;
    public IEnumerable<Nutricionista> Nutricionista { get; set; }
    public ListaModel(IRepositorioNutricionista _RepoNutricionista)
    {
      this._RepoNutricionista = _RepoNutricionista;
    }
    public void OnGet()
    {
      Nutricionista = _RepoNutricionista.AllNutricionistas();
    }
  }
}

