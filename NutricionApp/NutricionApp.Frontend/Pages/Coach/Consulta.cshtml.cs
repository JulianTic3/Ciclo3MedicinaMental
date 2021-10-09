using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;


namespace NutricionApp.Frontend.Pages
{
    public class ConsultaModel : PageModel
 {
        private readonly IRepositorioCoach repoCoach;
        public IEnumerable<Coach> Coach {get; set;}
        public ConsultaModel(IRepositorioCoach repoCoach)
        {
            this.repoCoach=repoCoach;
        }
        public void OnGet()
        {
            Coach= repoCoach.GetAllCoach();
        }
    }
}

