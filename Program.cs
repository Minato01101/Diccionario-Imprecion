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

            FileStream archivo = File.Create("..\\..\\Modelo\\Matricula.txt");
            archivo.Close();

            do
            {
                Dictionary<String, List<Alumno>> dicionarioGrupos;
                dicionarioGrupos = new Dictionary<string, List<Alumno>>();
                Console.WriteLine("Ingrese el nombre de la materia");
                Materia = Console.ReadLine();

                do
                {
                    List<Alumno> listaAlumno = new List<Alumno>();
                    Console.WriteLine($"Ingrese el numero de grupo para materia {Materia}");
                    numeroGrupos = Console.ReadLine();

                    do
                    {
                        Alumno alumnoItem = new Alumno();
                        alumnoItem.guerdarDatos();

                        //Se crea la lista de de alumnos 
                        listaAlumno.Add(alumnoItem);

                    } while (validarCondicion("otro Alumno"));
                    
                    //Se crea del grupo diccionario
                    dicionarioGrupos.Add(numeroGrupos,listaAlumno); 
                } while (validarCondicion("otro Grupo"));

                //Se crea el diccionario 
                Matricula.Add(Materia, dicionarioGrupos);

            } while (validarCondicion("otra Materia"));

            //Mostrando
            foreach (var itemMatricula in Matricula)
            {
                Console.WriteLine($"MATERIA -> {itemMatricula.Key}");

                foreach (var itemGrupo in itemMatricula.Value)
                {
                    Console.WriteLine($"GRUPO -> {itemGrupo.Key}");
                    foreach (var itemAlumnos in itemGrupo.Value)
                    {
                        itemAlumnos.ToString();
                        Console.WriteLine(itemAlumnos.ToString());
                    }
                }
            }

            CrearDocumento(Matricula);
            Console.WriteLine("Se muestra el Txt\n\n");
            MostrarTxt();
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

        static void CrearDocumento(Dictionary<String, Dictionary<String, List<Alumno>>> Matricula)
        {
            StreamWriter archivo = new StreamWriter("..\\..\\Modelo\\Matricula.txt",true, Encoding.UTF8);

            foreach (var itemMatricula in Matricula)
            {
                archivo.WriteLine($"MATERIA -> {itemMatricula.Key}");

                foreach (var itemGrupo in itemMatricula.Value)
                {
                    archivo.WriteLine($"GRUPO -> {itemGrupo.Key}");   
                    foreach (var itemAlumnos in itemGrupo.Value)
                    {
                        
                        archivo.WriteLine(itemAlumnos.ToString());
                    }
                }
            }

            archivo.Close();
        }

        static void MostrarTxt()
        {
            string Contenido;
            StreamReader stream = new StreamReader("..\\..\\Modelo\\Matricula.txt"); 

            Contenido = stream.ReadToEnd();
            Console.WriteLine(Contenido);

        }
    }
}
