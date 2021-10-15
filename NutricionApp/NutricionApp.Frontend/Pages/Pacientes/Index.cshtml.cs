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
        public Paciente Paciente { get; set; }
        public Nutricionista Nutricionista { get; set; }
        public IEnumerable<Nutricionista> list;
        public Coach Coach { get; set; }

        public IndexModel(IRepositorioPaciente _repoPaciente, IRepositorioNutricionista _repoNutricionista)
        {
            this._repoPaciente = _repoPaciente;
            this._repoNutricionista = _repoNutricionista;
        }

        public IActionResult OnGet(/*int id*/)
        {
            Paciente = _repoPaciente.GetPaciente(1);
            list = _repoNutricionista.AllNutricionistas();
            /*Console.WriteLine(Paciente.Nombre);
            Console.WriteLine(Paciente.Nutricionista.Nombre);
            if (Paciente.Nutricionista == null)
            {
                Nutricionista = new Nutricionista();
            }
            else
            {
                Nutricionista = Paciente.Nutricionista;
            }*/
            return Page();
        }

        public IActionResult OnPost(Nutricionista nutricionista, Paciente paciente)
        {
            if (nutricionista.Id != 0)
            {
                Nutricionista = _repoNutricionista.GetNutricionista(nutricionista.Id);
                Console.WriteLine(Nutricionista.Id);
                _repoPaciente.AsignarNutricionista(paciente.Id, nutricionista.Id);
                //Paciente.Nutricionista = Nutricionista;
            }
            return RedirectToPage("./Index");
        }
    }
}
