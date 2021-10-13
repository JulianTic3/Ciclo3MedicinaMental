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
    public class ActualizarModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente {get;set;}

        public ActualizarModel(IRepositorioPaciente _repoPaciente)
        {
            this._repoPaciente = _repoPaciente;
        }
        public IActionResult OnGet(int id)
        {
            Paciente = _repoPaciente.GetPaciente(id);
            if(Paciente==null)
            {
                return NotFound();            
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Paciente paciente)
        {
            _repoPaciente.UpdatePaciente(paciente);
            return RedirectToPage("Index");
        }
    }
}
