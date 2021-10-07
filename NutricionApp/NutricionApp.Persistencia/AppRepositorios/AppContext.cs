using NutricionApp.Dominio;
using Microsoft.EntityFrameworkCore;
namespace NutricionApp.Persistencia
{
  public class AppContext : DbContext
  {
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Nutricionista> Nutricionistas { get; set; }
    public DbSet<Coach> Coachs { get; set; }
    public DbSet<Historia> Historias { get; set; }
    public DbSet<SugerenciaCuidado> SugerenciasCuidados { get; set; }
    public DbSet<Valoracion> Valoraciones { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder
        .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = NutricionDB");
      }
    }
  }
}