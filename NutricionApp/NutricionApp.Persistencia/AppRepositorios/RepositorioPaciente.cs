using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public class RepositorioPaciente : IRepositorioPaciente
  {
    private readonly AppContext _appContext;
    public RepositorioPaciente(AppContext appContext)
    {
      _appContext = appContext;
    }
    public Paciente AddPaciente(Paciente Paciente)
    {
      var PacienteAdicionado = _appContext.Pacientes.Add(Paciente);
      _appContext.SaveChanges();
      return PacienteAdicionado.Entity;
    }

    public IEnumerable<Paciente> AllPacientes()
    {
      return _appContext.Pacientes;
    }

    public Coach AsignarCoach(int idPaciente, int idCoach)
    {
      var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
      if (pacienteEncontrado != null)
      {
        var CoachEncontrado = _appContext.Coachs.FirstOrDefault(c => c.Id == idCoach);
        if (CoachEncontrado != null)
        {
          pacienteEncontrado.Coach = CoachEncontrado;
          _appContext.SaveChanges();
        }
        return CoachEncontrado;
      }
      return null;
    }

    public Nutricionista AsignarNutricionista(int idPaciente, int idNutricionista)
    {
      var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
      if (pacienteEncontrado != null)
      {
        var NutricionistaEncontrado = _appContext.Nutricionistas.FirstOrDefault(m => m.Id == idNutricionista);
        if (NutricionistaEncontrado != null)
        {
          pacienteEncontrado.Nutricionista = NutricionistaEncontrado;
          _appContext.SaveChanges();
        }
        return NutricionistaEncontrado;
      }
      return null;
    }

    public void DeletePaciente(int IdPaciente)
    {
      var PacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == IdPaciente);
      if (PacienteEncontrado == null)
        return;
      _appContext.Pacientes.Remove(PacienteEncontrado);
      _appContext.SaveChanges();
    }

    public Paciente GetPaciente(int IdPaciente)
    {
      return _appContext.Pacientes.FirstOrDefault(p => p.Id == IdPaciente);
    }

    public Paciente UpdatePaciente(Paciente Paciente)
    {
      var PacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == Paciente.Id);
      if (PacienteEncontrado != null)
      {
        PacienteEncontrado.Id = Paciente.Id;
        PacienteEncontrado.Nombre = Paciente.Nombre;
        PacienteEncontrado.Apellidos = Paciente.Apellidos;
        PacienteEncontrado.Identificacion = Paciente.Identificacion;
        PacienteEncontrado.FechaNacimiento = Paciente.FechaNacimiento;
        PacienteEncontrado.Correo = Paciente.Correo;
        PacienteEncontrado.Contrasena = Paciente.Contrasena;
        PacienteEncontrado.Genero = Paciente.Genero;
        PacienteEncontrado.Ciudad = Paciente.Ciudad;
        PacienteEncontrado.Direccion = Paciente.Direccion;
        PacienteEncontrado.Telefono = Paciente.Telefono;
        PacienteEncontrado.Latitud = Paciente.Latitud;
        PacienteEncontrado.Longitud = Paciente.Longitud;
        PacienteEncontrado.Nutricionista = Paciente.Nutricionista;
        PacienteEncontrado.Coach = Paciente.Coach;

        _appContext.SaveChanges();
      }
      return PacienteEncontrado;
    }
  }
}