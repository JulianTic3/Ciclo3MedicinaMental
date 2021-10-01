using System;
using NutricionApp.Persistencia;
using NutricionApp.Dominio;

namespace NutricionApp.Consola
{
  class Program
  {
    private static IRepositorioPaciente _RepoPaciente = new RepositorioPaciente(new NutricionApp.Persistencia.AppContext());
    private static IRepositorioNutricionista _RepoNutricionista = new RepositorioNutricionista(new NutricionApp.Persistencia.AppContext());
    private static IRepositorioCoach _RepoCoach = new RepositorioCoach(new NutricionApp.Persistencia.AppContext());
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World! Probando el MAIN");
      //AddPaciente();
      //borrarPaciente(2);
      //buscarPaciente(3);
      //ActualizarPaciente(3);
      //AddNutricionista();
      //AsignarNutricionista(3, 4);
      //AddCoach();
    }
    private static void AddPaciente()
    {
      var Paciente = new Paciente
      {
        Nombre = "Maria",
        Apellidos = "Arciniegas Lopez",
        Telefono = "3005215469",
        Direccion = "calle 21 No. 36-25",
        Latitud = 75.236512F,
        Longitud = 5.265811F,
        Ciudad = "Cali",
        FechaNacimiento = new DateTime(1989, 08, 21)
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
        FechaNacimiento = new DateTime(1991, 05, 26)
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
    private static void AddCoach()
    {
      var Coach = new Coach
      {
        Nombre = "Carlos",
        Apellidos = "Ramirez Lopez",
        Telefono = "3005695869",
        Correo = "robert@hotmail.com",
        Identificacion = 38850214,
        Contrasena = "1234",
        Especialidad = "Entrenador deportivo",
        NumeroCertificacion = "25654"
      };
      _RepoCoach.AddCoach(Coach);
    }
  }
}