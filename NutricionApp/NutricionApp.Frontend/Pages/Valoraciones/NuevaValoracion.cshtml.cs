using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;

namespace NutricionApp.Frontend.Pages.Valoraciones
{
    public class NuevaValoracionModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public Paciente Paciente { get; set; }
        public Valoracion Valoracion { get; set; }
        public string Peso { get; set; }
        public string Estatura { get; set; }
        public string Calorias { get; set; }
        public string IdPaciente { get; set; }

        public NuevaValoracionModel(IRepositorioPaciente _repoPaciente, IRepositorioValoracion _repoValoracion)
        {
            this._repoPaciente = _repoPaciente;
        }
        public IActionResult OnGet(int Id)
        {
            Paciente = _repoPaciente.GetPaciente(Id);
            Valoracion = new Valoracion();
            return Page();
        }

        public IActionResult OnPost(Valoracion valoracion, string peso, string estatura, string calorias, int idPaciente)
        {
            valoracion.Peso = float.Parse(peso);
            valoracion.Estatura = float.Parse(estatura);
            valoracion.CaloriasConsumidas = float.Parse(calorias);
            Paciente = _repoPaciente.GetPaciente(idPaciente);
            if (Paciente.Valoraciones != null)
            {
                Paciente.Valoraciones.Add(valoracion);
            }
            else
            {
                Paciente.Valoraciones = new List<Valoracion> {
                    valoracion
                };
            }
            _repoPaciente.UpdatePaciente(Paciente);
            return RedirectToPage("../Pacientes/Index");
        }
    }
}

