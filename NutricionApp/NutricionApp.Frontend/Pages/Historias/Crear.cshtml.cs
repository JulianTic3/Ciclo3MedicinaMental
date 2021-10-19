using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages.Historias
{
    public class CrearModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente {get;set;}
        public Historia Historia {get;set;}
        public CrearModel(IRepositorioPaciente _repoPaciente, IRepositorioHistoria _repoHistoria)
        {
            this._repoHistoria = _repoHistoria;
            this._repoPaciente = _repoPaciente;
        }
        public IActionResult OnGet(int id)
        {
            Paciente = _repoPaciente.GetPaciente(id);
            Historia = new Historia();
            return Page();
        }

        public IActionResult OnPost(Paciente paciente, Historia historia)
        {
            Historia = _repoPaciente.AddHistoria(paciente.Id, historia);
            return RedirectToPage("VerHistoria", new {id = paciente.Id, historia = Historia.Id});
        }
    }
}
