using System;
using System.Collections.Generic;
using NutricionApp.Dominio;
namespace NutricionApp.Persistencia
{
    public interface IRepositorioValoracion{
        IEnumerable<Valoracion> getAllValoraciones();
        Valoracion addValoracion(Valoracion valoracion);
        Valoracion getValoracion(int idValoracion);
        Valoracion updateValoracion(Valoracion valoracion);
        void removeValoracion(int idValoracion);
    }
}