using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;

namespace NutricionApp.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistoria();
        Historia AddHistoria(Historia historia);
        Historia UpdateHistoria(Historia historia);
        void DeleteHistoria(int IdHistoria);
        Historia GetHistoria(int IdHistoria);
        
        Historia GetHistoriaFromPaciente(int IdPaciente);
    }
}