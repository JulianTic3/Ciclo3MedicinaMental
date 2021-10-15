using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;

namespace NutricionApp.Frontend.Pages.Valoraciones
{
    public class NuevaValoracionModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        private readonly IRepositorioValoracion _repoValoracion;
        public Paciente Paciente { get; set; }
        public Valoracion Valoracion { get; set; }

        public NuevaValoracionModel(IRepositorioPaciente _repoPaciente, IRepositorioValoracion _repoValoracion)
        {
            this._repoPaciente = _repoPaciente;
            this._repoValoracion = _repoValoracion;
        }
        public void OnGet(/*int id*/)
        {
            Paciente = _repoPaciente.GetPaciente(1);
            Valoracion = new Valoracion();
        }

        public IActionResult OnPost(Valoracion valoracion)
        {
            
            _repoValoracion.addValoracion(valoracion);
            return RedirectToPage("./Pacientes/Index");
        }
    }
}
