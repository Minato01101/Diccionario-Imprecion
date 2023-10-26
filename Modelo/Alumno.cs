using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Diccionario_Imprecion.Modelo
{
    class Alumno
    {
        public string numeroCarnet { get; set; }
        public string nombre { get; set; }
        public double[] notas { get; set; }

        public double promedio { get; set; }

        public void guerdarDatos()
        {
            //Se pide al usuario que ingrese sus datos
            this.notas = new double[4]; 
            Console.WriteLine("Ingrese el numero de carnet");
            this.numeroCarnet = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre");
            this.nombre = Console.ReadLine();

            //Se solicita al usario que ingrese las notas
            for (int i = 0; i < this.notas.Length; i++)
            {
                Console.Write($"Ingrese la nota {i+1}: ");
                notas[i] = double.Parse(Console.ReadLine());
            }
            calcularPromedio();

        }

        public void calcularPromedio()
        {
            double suma = 0;
            for (int i = 0; i < this.notas.Length; i++)
            {
                suma += notas[i];
            }

            this.promedio = suma/this.notas.Length;
        }


        public void MostrarDatos()
        {
            Console.WriteLine($"Numero de carnet -> {this.numeroCarnet}");
            Console.WriteLine($"Nombre -> {this.nombre}");
            Console.WriteLine($"Promedio -> {this.promedio}");
            Console.WriteLine(this.promedio < 6? "Reprobado":"Aprobado");
            Console.WriteLine("NOTAS: ");
            for (int i = 0; i < this.notas.Length; i++)
            {
                Console.Write($"\t {notas[i]}");
            }

        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            sr.AppendLine($"Numero de carnet -> {this.numeroCarnet}");
            sr.AppendLine($"Nombre -> {this.nombre}");
            sr.AppendLine($"Promedio -> {this.promedio}");

            sr.Append("Notas -> ");
            for (int i = 0; i < this.notas.Length; i++)
            {
                sr.Append($"{notas[i]} ");
            }

            return sr.ToString();
        }

    }
}
 