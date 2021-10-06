using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Dominio;
namespace NutricionApp.Persistencia
{
    public class RepositorioValoracion : IRepositorioValoracion
    {
        private readonly AppContext _appContext;

        public RepositorioValoracion(){
            _appContext = new AppContext();
        }
        public Valoracion addValoracion(Valoracion valoracion)
        {
            var nuevaValoracion = _appContext.Valoraciones.Add(valoracion);
            _appContext.SaveChanges();
            return nuevaValoracion.Entity;
        }

        public IEnumerable<Valoracion> getAllValoraciones()
        {
            return _appContext.Valoraciones;
        }

        public Valoracion getValoracion(int idValoracion)
        {
            return _appContext.Valoraciones.FirstOrDefault(v=>v.Id == idValoracion);
        }

        public void removeValoracion(int idValoracion)
        {
            var valoracionEncontrado = _appContext.Valoraciones.FirstOrDefault(v=>v.Id == idValoracion);
            if(valoracionEncontrado == null)
                return;
            _appContext.Valoraciones.Remove(valoracionEncontrado);
            _appContext.SaveChanges();
        }

        public Valoracion updateValoracion(Valoracion valoracion)
        {
            var valoracionEncontrado = _appContext.Valoraciones.FirstOrDefault(v=>v.Id == valoracion.Id);
            if(valoracionEncontrado != null){
                valoracionEncontrado.Fecha = valoracion.Fecha;
                valoracionEncontrado.Peso = valoracion.Peso;
                valoracionEncontrado.Estatura = valoracion.Estatura;
                valoracionEncontrado.CaloriasConsumidas = valoracion.CaloriasConsumidas;
                valoracionEncontrado.Historia = valoracion.Historia;
                _appContext.SaveChanges();
            }
            return valoracionEncontrado;
        }
    }
}