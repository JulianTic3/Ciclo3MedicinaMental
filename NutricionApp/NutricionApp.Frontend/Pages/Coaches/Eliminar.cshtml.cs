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
    public class EliminarModel : PageModel
 {
        private readonly IRepositorioCoach repoCoach;
        public Coach Coach {get; set;}
        public EliminarModel(IRepositorioCoach repoCoach)
        {
            this.repoCoach=repoCoach;
        }
        public IActionResult OnGet(int id)
        {
            Coach=repoCoach.GetCoach(id);
            if(Coach==null)
            {
                return NotFound();
            }
            else 
            {
                return Page();
            }
        }
        public IActionResult OnPost(int id)
        {
            repoCoach.DeleteCoach(id);
            return RedirectToPage("Consulta");
        }
    }
}
