using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages.Pacientes
{
  public class SugerenciasModel : PageModel
  {
    private readonly IRepositorioPaciente _repoPaciente;
    public SugerenciaCuidado SugerenciaCuidado { get; set; }
    public Paciente Paciente { get; set; }
    public SugerenciasModel(IRepositorioPaciente _repoPaciente)
    {
      this._repoPaciente = _repoPaciente;
    }
    public IActionResult OnGet(int id)
    {
      Paciente = _repoPaciente.GetPaciente(id);
      if (Paciente != null)
      {
        return Page();
      }
      else
      {
       return RedirectToPage("./NotFound");
      }
    }
    public IActionResult OnPost(int id, SugerenciaCuidado sugerenciaCuidado)
    {
      _repoPaciente.AddSugerencia(id, sugerenciaCuidado);
      return RedirectToPage("/Nutricionistas/PacientesNutricionista");
    }
  }
}
