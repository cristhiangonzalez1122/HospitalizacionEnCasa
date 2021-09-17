using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {

        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            //AddPaciente();
            //BuscarPaciente(2);
            //MostrarPacientes();
            //AddMedico();
            //BuscarMedico(9);
            //AsignarMedico();
            //AddEnfermera();
            AsignarEnfermera();

        }

        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Juan Carlos",
                Apellidos = "Sabra",
                NumeroTelefono = "3117741121",
                Genero = Genero.Masculino,
                Direccion = "cra 42 73 22",
                Longitud = 5.076152F,
                Latitud = -75.52290F,
                Ciudad = "Cali",
                FechaNacimiento = new DateTime(1986, 12, 02)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        }

        private static void MostrarPacientes()
        {
            var pacientes = _repoPaciente.GetAllPacientes();
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
            }

        }

        private static void AddMedico()
        {
            var medico = new Medico
            {
                Nombre = "David",
                Apellidos = "Gomez",
                NumeroTelefono = "3135516612",
                Genero = Genero.Masculino,
                Especialidad = "Cirujano Plastico",
                Codigo = "5142447",
                RegistroRethus = "si"
            };
            _repoMedico.AddMedico(medico);
        }

        private static void BuscarMedico(int idMedico)
        {
            var medico = _repoMedico.GetMedico(idMedico);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos + " " + medico.Especialidad);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1, 9);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos);
        }

        private static void AddEnfermera()
        {
            var enfermera = new Enfermera
            {
                Nombre = "Maria",
                Apellidos = "Restrepo",
                NumeroTelefono = "3132258641",
                Genero = Genero.Femenino,
                TarjetaProfesional = "5524125",
                HorasLaborales = 8
            };
            _repoEnfermera.AddEnfermera(enfermera);
        }

        public static void AsignarEnfermera()
        {
            var enfermera = _repoPaciente.AsignarEnfermera(1,10);
            Console.WriteLine(enfermera.Nombre +" "+ enfermera.Apellidos);
        }        

    }
}
