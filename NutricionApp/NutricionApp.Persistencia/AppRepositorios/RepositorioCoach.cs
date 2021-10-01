using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;
namespace NutricionApp.Persistencia
{
  public class RepositorioCoach : IRepositorioCoach
  {
    private readonly AppContext _appContext;

    public RepositorioCoach(AppContext appContext)
    {
      _appContext = appContext;
    }
    IEnumerable<Coach> IRepositorioCoach.GetAllCoachs()
    {
      return _appContext.Coachs;
    }
    Coach IRepositorioCoach.AddCoach(Coach coach)
    {
      var nuevoCoach = _appContext.Coachs.Add(coach);
      _appContext.SaveChanges();
      return nuevoCoach.Entity;
    }
    Coach IRepositorioCoach.GetCoach(int idCoach)
    {
      return _appContext.Coachs.FirstOrDefault(p => p.Id == idCoach);
    }
    Coach IRepositorioCoach.UpdateCoach(Coach coach)
    {
      var coachEncontrado = _appContext.Coachs.FirstOrDefault(p => p.Id == coach.Id);
      if (coachEncontrado != null)
      {
        coachEncontrado.Identificacion = coach.Identificacion;
        coachEncontrado.Nombre = coach.Nombre;
        coachEncontrado.Apellidos = coach.Apellidos;
        coachEncontrado.Correo = coach.Correo;
        coachEncontrado.Telefono = coach.Telefono;
        coachEncontrado.Contrasena = coach.Contrasena;
        coachEncontrado.Especialidad = coach.Especialidad;
        coachEncontrado.NumeroCertificacion = coach.NumeroCertificacion;

        _appContext.SaveChanges();
      }
      return coachEncontrado;
    }
    void IRepositorioCoach.DeleteCoach(int idCoach)
    {
      var coachEncontrado = _appContext.Coachs.FirstOrDefault(p => p.Id == idCoach);
      if (coachEncontrado == null)
        return;
      _appContext.Remove(coachEncontrado);
      _appContext.SaveChanges();
    }
  }
}