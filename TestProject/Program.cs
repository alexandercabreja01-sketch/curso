using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Estudiante
{
    public string Nombre;
    public string Apellido;

    public double N1, N2, N3, N4;
    public double Promedio;
    public char Literal;
    
}

class Ejercicio2
{
    static void Main()
    {
        List<Estudiante> lista = new List<Estudiante>();
        int opcion = 0;
       
        while (opcion != 3)
      {  
        Console.WriteLine("==========================================================");
        Console.WriteLine("           Colegio Dios es bueno. Calificaciones           ");
        Console.WriteLine("==========================================================");
        Console.WriteLine("1: Añadir estudiante");
        Console.WriteLine("2: Eliminar estudiante");
        Console.WriteLine("3: Salir y guardar");
        Console.Write("Elija una opción: ");
        
        if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido (1, 2 o 3).");
                continue;
            }
        
            if (opcion == 1)
            {
                 string continuar = "S";

                  while (continuar.ToUpper() == "S")
                {
                  Estudiante e = new Estudiante();

                  Console.Write("\nNombre: ");
                  e.Nombre = Console.ReadLine();

                  Console.Write("Apellido: ");
                  e.Apellido = Console.ReadLine();

                 Console.Write("Nota 1: ");
                    double.TryParse(Console.ReadLine(), out e.N1);

                    Console.Write("Nota 2: ");
                    double.TryParse(Console.ReadLine(), out e.N2);

                    Console.Write("Nota 3: ");
                    double.TryParse(Console.ReadLine(), out e.N3);

                    Console.Write("Nota 4: ");
                    double.TryParse(Console.ReadLine(), out e.N4);

                  e.Promedio = (e.N1 + e.N2 + e.N3 + e.N4) / 4.0;

                  if (e.Promedio >= 90 && e.Promedio <= 100)
                  e.Literal = 'A';

                  else if (e.Promedio >= 80)
                  e.Literal = 'B';

                  else if (e.Promedio >= 70)
                  e.Literal = 'C';

                  else
                  e.Literal = 'F';

                  lista.Add(e);

                  Console.Write("\n¿Desea ingresar otro estudiante? (S/N): ");
                  continuar = Console.ReadLine();
                }
            }
            else if (opcion == 2)
            {
                Console.Write("\nIngrese el nombre del estudiante a eliminar: ");
                string nombreBuscar = Console.ReadLine();

                Estudiante encontrado = null;

                
                foreach (var est in lista)
                {
                    if (est.Nombre.ToLower() == nombreBuscar.ToLower())
                    {
                        encontrado = est;
                        break;
                    }
                }

                if (encontrado != null)
                {
                    lista.Remove(encontrado);
                    Console.WriteLine("Estudiante eliminado");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }
            }
      }
      bool existeArchivo = File.Exists("curso.txt");

      
        using (StreamWriter curso = new StreamWriter("curso.txt", true))
        {
            
            if (!existeArchivo)
            {
                curso.WriteLine("=========================================================================");
                curso.WriteLine("Nombre\tApellido\tNota1\tNota2\tNota3\tNota4\tPromedio\tLiteral");
                curso.WriteLine("=========================================================================");
            }

            var ordenada = lista.OrderBy(x => x.Apellido).ToList();

            foreach (var e in ordenada)
            {
                curso.WriteLine($"{e.Nombre}\t{e.Apellido}\t\t{e.N1}\t\t{e.N2}\t\t{e.N3}\t\t{e.N4}\t\t{e.Promedio:F1}\t\t{e.Literal}");
            }

        Console.WriteLine("\n==========================================================");
        Console.WriteLine("Estudiantes en A: " + lista.Count(x => x.Literal == 'A'));
        Console.WriteLine("Estudiantes en B: " + lista.Count(x => x.Literal == 'B'));
        Console.WriteLine("Estudiantes en C: " + lista.Count(x => x.Literal == 'C'));
        Console.WriteLine("Estudiantes Reprobados: " + lista.Count(x => x.Literal == 'F'));
        Console.WriteLine("==========================================================");

        }
    }
}