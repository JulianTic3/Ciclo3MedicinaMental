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
  public class PacientesNutricionistaModel : PageModel
  {
    private readonly IRepositorioPaciente _RepoPaciente;
    private readonly IRepositorioNutricionista _RepoNutricionista;
    public IEnumerable<Paciente> Pacientes { get; set; }
    public Nutricionista Nutricionista { get; set; }
    public PacientesNutricionistaModel(IRepositorioPaciente _RepoPaciente, IRepositorioNutricionista _RepoNutricionista)
    {
      this._RepoPaciente = _RepoPaciente;
      this._RepoNutricionista = _RepoNutricionista;
    }
    public IActionResult OnGet(int id)
    {
      Nutricionista = _RepoNutricionista.GetNutricionista(id);
      Pacientes = _RepoPaciente.GetPacientesNutricionista(id);
      if (Pacientes == null)
      {
        return NotFound();
      }
      else
      {
        return Page();
      }
    }
  }
}
