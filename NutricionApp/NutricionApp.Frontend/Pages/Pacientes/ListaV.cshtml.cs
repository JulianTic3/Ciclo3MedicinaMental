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
  public class ListaVModel : PageModel
  {
    private readonly IRepositorioPaciente _repoPaciente;
    [BindProperty]
    public Paciente Paciente { get; set; }
    public IEnumerable<Valoracion> Valoraciones { get; set; }
    public ListaVModel(IRepositorioPaciente _repoPaciente)
    {
      this._repoPaciente = _repoPaciente;
    }
    public void OnGet(int? PacienteId)
    {
      if (PacienteId.HasValue)
      {
        Paciente = _repoPaciente.GetPaciente(PacienteId.Value);
        if (Paciente == null)
        {
          RedirectToPage("./NotFound");
        }
        else
        {
          Valoraciones = _repoPaciente.GetValoracionPaciente(PacienteId.Value);
        }
      }
    }
  }
}
