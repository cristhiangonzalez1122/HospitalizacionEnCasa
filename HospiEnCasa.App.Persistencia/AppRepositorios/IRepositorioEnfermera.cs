using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioEnfermera
    {
        IEnumerable<Enfermera> GetAllEnfermeras();
        Enfermera AddEnfermera(Enfermera enfermera);
        Enfermera UpdateEnfermera(Enfermera enfermera);
        void DeleteEnfermera(int idEnfermera);
        Enfermera GetEnfermera(int idEnfermera);
        
    }
}