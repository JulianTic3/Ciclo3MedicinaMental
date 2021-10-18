using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages.Coaches
{
    public class CoachListaModel : PageModel
    {
        private readonly IRepositorioPaciente repoPaciente;
        private readonly IRepositorioCoach repoCoach;
        IEnumerable<Paciente> paciente {get; set;}
        public Coach coach {get; set;}
        public GetPacientesCoachModel(IRepositorioPaciente repoPaciente,IRepositorioCoach repoCoach)
        {
            this.repoPaciente=repoPaciente;
            this.repoCoach=repoCoach;
        }
        public void OnGet(int id)
        {
            paciente=repoPaciente.GetPacientesCoach(id);
            coach=repoPaciente.GetCoach(id);
            if(paciente==null)
            {
                return NotFound;
            }
            else
            {
                return Page();
            }
        }
    }
}
