using Diccionario_Imprecion.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Diccionario_Imprecion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Materia;
            string numeroGrupos;
            Dictionary<String, Dictionary<String, List<Alumno>>> Matricula;
            Matricula = new Dictionary<string, Dictionary<string, List<Alumno>>>();

            do
            {
                Dictionary<String, List<Alumno>> dicionarioGrupos;
                dicionarioGrupos = new Dictionary<string, List<Alumno>>();
                Console.WriteLine("Ingrese el nombre de la materia");
                Materia = Console.ReadLine();
                //Alumno alumnoItem = new Alumno();
                //List<Alumno> listaAlumno = new List<Alumno>();

                do
                {
                    List<Alumno> listaAlumno = new List<Alumno>();
                    Console.WriteLine($"Ingrese el numero de grupo para materia {Materia}");
                    numeroGrupos = Console.ReadLine();

                    do
                    {
                        Alumno alumnoItem = new Alumno();
                        alumnoItem.guerdarDatos();
                        listaAlumno.Add(alumnoItem);

                    } while (validarCondicion("otro Alumno"));

                    dicionarioGrupos.Add(numeroGrupos,listaAlumno); 
                } while (validarCondicion("otro Grupo"));

                Matricula.Add(Materia, dicionarioGrupos);
            } while (validarCondicion("otra Materia"));


            foreach (var itemMatricula in Matricula)
            {
                Console.WriteLine($"MATERIA -> {itemMatricula.Key}");

                foreach (var itemGrupo in itemMatricula.Value)
                {
                    Console.WriteLine($"GRUPO -> {itemGrupo.Key}");
                    foreach (var itemAlumnos in itemGrupo.Value)
                    {
                        itemAlumnos.MostrarDatos();
                    }
                }
            }
        }

        public static bool validarCondicion(string dato)
        {
            string condicion = "";
            Console.WriteLine($"Desea ingresar {dato} Preciones s para si\n cualquier tecla nono");
            condicion = Console.ReadLine();

            if(condicion.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
