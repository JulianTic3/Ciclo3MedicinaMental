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
    public IEnumerable<Paciente> Pacientes { get; set; }
    public PacientesNutricionistaModel(IRepositorioPaciente _RepoPaciente)
    {
      this._RepoPaciente = _RepoPaciente;
    }
    public IActionResult OnGet(int IdNutricionista)
    {
      Pacientes = _RepoPaciente.GetPacientesNutricionista(IdNutricionista);
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
