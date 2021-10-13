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
    public class RegistroModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente {get;set;}
        public Genero Genero {get;set;}
        
        public RegistroModel(IRepositorioPaciente _repoPaciente)
        {
            this._repoPaciente = _repoPaciente;
        }
        
        public void OnGet()
        {
            Paciente = new Paciente();
        }

        public IActionResult OnPost(Paciente paciente)
        {
            _repoPaciente.AddPaciente(paciente);
            return RedirectToPage("Index");
        }

    }
}
