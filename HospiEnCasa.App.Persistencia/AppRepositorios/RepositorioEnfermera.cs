using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {
        private readonly AppContext _appContext;

        public RepositorioEnfermera(AppContext appContext)
        {
            _appContext = appContext;

        }

      
        Enfermera IRepositorioEnfermera.AddEnfermera(Enfermera enfermera)
        {
            var enfermeraAdicionado = _appContext.Enfermeras.Add(enfermera);
            _appContext.SaveChanges();
            return enfermeraAdicionado.Entity;
        }

        void IRepositorioEnfermera.DeleteEnfermera(int idEnfermera)
        {
            var enfermeraEncontrado = _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
            if (enfermeraEncontrado == null)
                return;
            _appContext.Enfermeras.Remove(enfermeraEncontrado);
            _appContext.SaveChanges();    

        }

        IEnumerable<Enfermera> IRepositorioEnfermera.GetAllEnfermeras()
        {
            return _appContext.Enfermeras;
        }

        Enfermera IRepositorioEnfermera.GetEnfermera(int idEnfermera)
        {
            return _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
        }

        Enfermera IRepositorioEnfermera.UpdateEnfermera(Enfermera enfermera)
        {
            var enfermeraEncontrado = _appContext.Enfermeras.FirstOrDefault(e => e.Id == enfermera.Id);
            if(enfermeraEncontrado != null)
            {
                enfermeraEncontrado.Nombre = enfermera.Nombre;
                enfermeraEncontrado.Apellidos = enfermera.Apellidos;
                enfermeraEncontrado.NumeroTelefono = enfermera.NumeroTelefono;
                enfermeraEncontrado.Genero = enfermera.Genero;
                enfermeraEncontrado.TarjetaProfesional = enfermera.TarjetaProfesional;
                enfermeraEncontrado.HorasLaborales = enfermera.HorasLaborales;

                _appContext.SaveChanges();

            }
            return enfermeraEncontrado;
        }
    }
}