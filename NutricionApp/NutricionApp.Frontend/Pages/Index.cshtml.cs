﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPersona _repoPersona;
        public Persona Persona { set; get; }
        public string id { get; set; }
        
        public IndexModel(IRepositorioPersona _repoPersona)
        {
            this._repoPersona = _repoPersona;
        }

        public IActionResult OnPost(string id)
        {
            int cedula = Int32.Parse(id);
            Persona = _repoPersona.GetPersona(cedula);

            if (Persona != null)
            {
                if (Persona.Discriminator == "Paciente")
                {
                    return RedirectToPage("/Pacientes/Index", new {id=Persona.Id});
                }
                if (Persona.Discriminator == "Nutricionista")
                {
                    return RedirectToPage("/Nutricionistas/PacientesNutricionista", new {id=Persona.Id});
                }
                else
                {
                  return RedirectToPage("/Coaches/CoachLista",new {id=Persona.Id});
                }

            }
            else
            {
                return RedirectToPage("/NoEncontrado/NoEncontrado");
            }
        }
    }
}
