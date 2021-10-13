using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;

namespace NutricionApp.Frontend.Pages.Pacientes
{
    public class InfoModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente {get;set;}

        public InfoModel(IRepositorioPaciente _repoPaciente)
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
    }
}
