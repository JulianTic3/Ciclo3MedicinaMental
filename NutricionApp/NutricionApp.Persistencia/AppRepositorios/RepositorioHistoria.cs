using System.Collections.Generic;
using NutricionApp.Dominio;
using NutricionApp.Persistencia;
using System.Linq; 
using System;

namespace NutricionApp.Persistencia
{
    public class RepositorioHistoria:IRepositorioHistoria
    {
        private readonly NutricionApp.Persistencia.AppContext _appContext= new AppContext();
        Historia IRepositorioHistoria.AddHistoria(Historia historia)
        {
            var historiaAdd=_appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAdd.Entity;
        }
        Historia IRepositorioHistoria.UpdateHistoria(Historia historia)
        {
             var historiaBusqueda=_appContext.Historias.FirstOrDefault(p => p.Id==historia.Id);
            if(historiaBusqueda!=null)
            {
                historiaBusqueda.Fecha=historia.Fecha;
                historiaBusqueda.Diagnostico=historia.Diagnostico;
                
                _appContext.SaveChanges();
            }   
            return historiaBusqueda;
        }
        void IRepositorioHistoria.DeleteHistoria(int IdHistoria)
        {
            var historiaBusqueda=_appContext.Historias.FirstOrDefault(p => p.Id==IdHistoria);
            if(historiaBusqueda==null)
            return;
            _appContext.Historias.Remove(historiaBusqueda);
            _appContext.SaveChanges();
        }
        Historia IRepositorioHistoria.GetHistoria(int IdHistoria)
        {
            var historiaBusqueda=_appContext.Historias.FirstOrDefault(p => p.Id==IdHistoria);
            return historiaBusqueda;
        }
        IEnumerable<Historia> IRepositorioHistoria.GetAllHistoria()
        {
            return _appContext.Historias;
        }

        Historia IRepositorioHistoria.GetHistoriaFromPaciente(int IdPaciente)
        {
            var paciente = _appContext.Pacientes.Find(IdPaciente);
            return paciente.Historia;
        }
    }
}