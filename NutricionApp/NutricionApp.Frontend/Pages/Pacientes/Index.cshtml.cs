using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        private readonly IRepositorioNutricionista _repoNutricionista;
        private readonly IRepositorioCoach _repoCoach;
        public Paciente Paciente { get; set; }
        public Nutricionista Nutricionista { get; set; }
        public IEnumerable<Nutricionista> listNutricionista;
        public IEnumerable<Coach> listCoaches;
        public Coach Coach { get; set; }

        public IndexModel(IRepositorioPaciente _repoPaciente, IRepositorioCoach _repoCoach, IRepositorioNutricionista _repoNutricionista)
        {
            this._repoPaciente = _repoPaciente;
            this._repoNutricionista = _repoNutricionista;
            this._repoCoach = _repoCoach;
        }

        public IActionResult OnGet(/*int id*/)
        {
            Paciente = _repoPaciente.GetPaciente(1);
            listNutricionista = _repoNutricionista.AllNutricionistas();
            listCoaches = _repoCoach.GetAllCoach();
            if (Nutricionista == null)
            {
                Nutricionista = new Nutricionista();
            }

            if (Coach == null)
            {
                Coach = new Coach();
            }
            
            return Page();
        }

        public IActionResult OnPost(Nutricionista nutricionista, Coach coach, Paciente paciente)
        {
            if (nutricionista != null)
            {
                Nutricionista = _repoNutricionista.GetNutricionista(nutricionista.Id);
                _repoPaciente.AsignarNutricionista(paciente.Id, nutricionista.Id);
            }
            if (coach != null)
            {
                Coach = _repoCoach.GetCoach(coach.Id);
                _repoPaciente.AsignarCoach(paciente.Id, coach.Id);
            }
            return RedirectToPage("./Index");
        }
    }
}
