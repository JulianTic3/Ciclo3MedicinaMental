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
    public class RegistroModel : PageModel
    {
        private readonly IRepositorioCoach repoCoach;
        public Coach coach{get; set;}
        public RegistroModel(IRepositorioCoach repoCoach)
        {
            this.repoCoach=repoCoach;
        }
        public void OnGet()//metodo ONGet sollo sive para  llevar datos desde el backend hasta el frotnend
        {
            coach=new Coach();
        }
        public IActionResult OnPost(Coach coach)//metodo q me sive para llevar los datos desde el frontend a la base de datos 
        {
            repoCoach.AddCoach(coach);
            return RedirectToPage("Index");
        }
    }
}

