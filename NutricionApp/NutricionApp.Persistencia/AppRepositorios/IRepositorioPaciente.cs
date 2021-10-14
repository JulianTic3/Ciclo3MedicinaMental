using System;
using System.Collections.Generic;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
  public interface IRepositorioPaciente
  {
    IEnumerable<Paciente> AllPacientes();
    IEnumerable<Paciente> GetPacientesNutricionista(int id);
    IEnumerable<Valoracion> GetValoracionPaciente(int PacienteId);
    IEnumerable<SugerenciaCuidado> GetSugerenciasCuidado(int PacienteId);
    IEnumerable<Historia> GetHistoriaClinica(int id);
    Paciente AddPaciente(Paciente Paciente);
    Paciente UpdatePaciente(Paciente Paciente);
    void DeletePaciente(int IdPaciente);
    Paciente GetPaciente(int IdPaciente);
    Nutricionista AsignarNutricionista(int idPaciente, int idNutricionista);
    Coach AsignarCoach(int idPaciente, int idCoach);
  }
}
