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
    public class VerHistoriaModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente {get;set;}
        public Historia Historia {get;set;}

        public VerHistoriaModel (IRepositorioPaciente _repoPaciente, IRepositorioHistoria _repoHistoria)
        {
            this._repoPaciente = _repoPaciente;
            this._repoHistoria = _repoHistoria;
        }
        public IActionResult OnGet(int id, int historia)
        {
            Paciente = _repoPaciente.GetPaciente(id);
            Historia = _repoHistoria.GetHistoria(historia);
            if(Historia != null)
            {
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
