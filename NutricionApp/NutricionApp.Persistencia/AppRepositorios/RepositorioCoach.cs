using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
 public class RepositorioCoach:IRepositorioCoach
    {
        private readonly NutricionApp.Persistencia.AppContext _appContext= new AppContext();
        
        Coach IRepositorioCoach.AddCoach(Coach coach)
        {
            var coachAdd=_appContext.Coachs.Add(coach);
            _appContext.SaveChanges();
            return coachAdd.Entity;
        }
        Coach IRepositorioCoach.UpdateCoach(Coach coach)
        {
             var coachBusqueda=_appContext.Coachs.FirstOrDefault(p => p.Id==coach.Id);
            if(coachBusqueda!=null)
            {
                coachBusqueda.Nombre=coach.Nombre;
                coachBusqueda.Identificacion=coach.Identificacion;
                coachBusqueda.Apellidos=coach.Apellidos;
                coachBusqueda.Telefono=coach.Telefono;
                coachBusqueda.Correo=coach.Correo;
                coachBusqueda.Contrasena=coach.Contrasena;
                coachBusqueda.Especialidad=coach.Especialidad;
                coachBusqueda.NumeroCertificacion=coach.NumeroCertificacion;
                
                _appContext.SaveChanges();
            }   
            return coachBusqueda;
        }
        void IRepositorioCoach.DeleteCoach(int IdCoach)
        {
            var coachBusqueda=_appContext.Coachs.FirstOrDefault(p => p.Id==IdCoach);
            if(coachBusqueda==null)
            return;
            _appContext.Coachs.Remove(coachBusqueda);
            _appContext.SaveChanges();
        }
        Coach IRepositorioCoach.GetCoach(int IdCoach)
        {
            var coachBusqueda=_appContext.Coachs.FirstOrDefault(p => p.Id==IdCoach);
            return coachBusqueda;
        }
        IEnumerable<Coach> IRepositorioCoach.GetAllCoach()
        {
            return _appContext.Coachs;
        }
    }
}