using System;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;
using System.Collections.Generic;

namespace NutricionApp.Consola
{
  class Program
  {
    private static IRepositorioPaciente _RepoPaciente = new RepositorioPaciente();
    private static IRepositorioNutricionista _RepoNutricionista = new RepositorioNutricionista();
    private static IRepositorioPersona _RepoPersona = new RepositorioPersona();
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World! Probando el MAIN");
      //AddPaciente();
      //borrarPaciente(2);
      //buscarPaciente(6);
      //ActualizarPaciente(3);
      //AddNutricionista();
      //AsignarNutricionista(3, 4);
      //listaPacientesnu(7);
      //GetPersona(12654963);
    }
    private static void AddPaciente()
    {
      var Paciente = new Paciente
      {
        Nombre = "Andrea Carolina",
        Apellidos = "Lopez Lopez",
        Telefono = "3005695147",
        Direccion = "calle 36 No. 36-25",
        Latitud = 75.236598F,
        Longitud = 5.265833F,
        Ciudad = "Pereira",
        FechaNacimiento = new DateTime(1990, 05, 26),
        SugerenciasCuidados = new List<SugerenciaCuidado>
        {
          new SugerenciaCuidado { Fecha = new DateTime(2021, 10, 22, 11, 00, 0), Descripcion = "tomar ibuprofeno 2 veces al dia" }
        }
      };
      _RepoPaciente.AddPaciente(Paciente);
    }
    private static void buscarPaciente(int idPaciente)
    {
      var Paciente = _RepoPaciente.GetPaciente(idPaciente);
      Console.WriteLine(Paciente.Nombre + " " + Paciente.Apellidos + " -- Dirección: " + Paciente.Direccion);
    }
    private static void borrarPaciente(int idPaciente)
    {
      _RepoPaciente.DeletePaciente(idPaciente);
    }
    private static void ActualizarPaciente(int IdPaciente)
    {
      var Paciente = new Paciente
      {
        Id = 3,
        Nombre = "Efrain",
        Apellidos = "Ramirez Valderrama",
        Telefono = "3005695869",
        Direccion = "calle 25 No. 36-25",
        Latitud = 75.236598F,
        Longitud = 5.265833F,
        Ciudad = "Cúcuta",
        FechaNacimiento = new DateTime(1991, 05, 26),
      };
      _RepoPaciente.UpdatePaciente(Paciente);
    }
    private static void AddNutricionista()
    {
      var Nutricionista = new Nutricionista
      {
        Nombre = "Carlos",
        Apellidos = "Ramirez Lopez",
        Telefono = "3005695869",
        Correo = "robert@hotmail.com",
        Identificacion = 38850214,
        Contrasena = "1234",
        TarjetaProfesional = "25147"
      };
      _RepoNutricionista.AddNutricionista(Nutricionista);
    }
    private static void AsignarNutricionista(int idPaciente, int IdNutricionista)
    {
      _RepoPaciente.AsignarNutricionista(3, 4);
    }
    private static void GetPersona(int cedula)
    {
      var Persona = _RepoPersona.GetPersona(cedula);
      Console.WriteLine(Persona.Nombre + " " + Persona.Discriminator);
    }
  }
}