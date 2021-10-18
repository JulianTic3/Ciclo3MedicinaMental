using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;
using Microsoft.EntityFrameworkCore;

namespace NutricionApp.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext = new AppContext();
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

        public Paciente GetPaciente(int id)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == id);
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

        public IEnumerable<Paciente> GetPacientesNutricionista(int id)
        {
            var paciente = _appContext.Pacientes.Where(p => p.Nutricionista.Id == id).ToList();
            return paciente;
            // retorna la lista de pacientes que esten asignados a un nutrcionista en especial
        }

        public IEnumerable<Valoracion> GetValoracionPaciente(int PacienteId)
        {
            var paciente = _appContext.Pacientes.Where(p => p.Id == PacienteId).Include(p => p.Valoraciones).FirstOrDefault();
            return paciente.Valoraciones;
            // este método debe retornar la lista de las valoraciones de un paciente especifico
        }
        public IEnumerable<SugerenciaCuidado> GetSugerenciasCuidado(int PacienteId)
        {
            var paciente = _appContext.Pacientes.Where(p => p.Id == PacienteId).Include(p => p.SugerenciasCuidados).FirstOrDefault();
            return paciente.SugerenciasCuidados;
            // este método debe retornar la lista de las sugerencias de un paciente especifico
        }
        public IEnumerable<Historia> GetHistoriaClinica(int id)
        {
            var historia = _appContext.Historias.Where(h => h.Id == id).ToList();
            return historia;
            // este método debe retornar la lista de las anotaciones en la historia clinia de un paciente especifico
        }
        public void AddSugerencia(int id, SugerenciaCuidado SugerenciaCuidado)
        {
            var paciente = _appContext.Pacientes.Find(id);
            if (paciente != null)
            {
                if (paciente.SugerenciasCuidados != null)
                {
                    paciente.SugerenciasCuidados.Add(SugerenciaCuidado);
                }
                else
                {
                    paciente.SugerenciasCuidados = new List<SugerenciaCuidado>();
                    paciente.SugerenciasCuidados.Add(SugerenciaCuidado);
                }
                var PacienteEncontrado = _appContext.Pacientes.Find(paciente.Id);
                if (PacienteEncontrado != null)
                {
                    PacienteEncontrado.Nombre = paciente.Nombre;
                    PacienteEncontrado.Apellidos = paciente.Apellidos;
                    PacienteEncontrado.Identificacion = paciente.Identificacion;
                    PacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                    PacienteEncontrado.Correo = paciente.Correo;
                    PacienteEncontrado.Contrasena = paciente.Contrasena;
                    PacienteEncontrado.Genero = paciente.Genero;
                    PacienteEncontrado.Ciudad = paciente.Ciudad;
                    PacienteEncontrado.Direccion = paciente.Direccion;
                    PacienteEncontrado.Telefono = paciente.Telefono;
                    PacienteEncontrado.Latitud = paciente.Latitud;
                    PacienteEncontrado.Longitud = paciente.Longitud;
                    _appContext.SaveChanges();
                }
            }
        }
        Historia IRepositorioPaciente.AddHistoria(int IdPaciente, Historia historia)
        {
            var paciente = _appContext.Pacientes.Find(IdPaciente);
            if (paciente != null)
            {
                _appContext.Historias.Add(historia);
                paciente.Historia = historia;
                UpdatePaciente(paciente);
            }
            return historia;
        }
        public IEnumerable<Paciente> GetPacientesCoach(int id)
            {
                var paciente=_appContext.Pacientes.Where(p => p.Coach.Id==id).ToList();
                return paciente;
            }
    }

}