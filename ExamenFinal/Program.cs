using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{


    class Program
    {
        static void Main(string[] args)
        {
            int[,] L = {
           // s  a  b  c  d  e  f  g  h  i  t
            { 0, 1, 0, 0, 4, 0, 0, 6, 0, 0, 0 },
            { 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 },
            { 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 2, 0, 0, 3, 0, 0, 3, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 2, 1, 0, 0, 3, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };



            string[] nodos = { "S", "A", "B", "C", "D", "E", "F", "G", "H", "I", "T" };

            var DJISKTRA = new DJISKTRA(L, nodos);

            Console.WriteLine("Matriz de Adyacencia: \n");
            DJISKTRA.MostrarRutaMatriz();

            Console.ForegroundColor = ConsoleColor.White; // el Encabezado -> Color Blanco.
            Console.WriteLine("\nRuta más corta entre S y T: ");
            DJISKTRA.Resolver("S", "T");
            Console.ReadLine();


            Console.ReadKey();
        }
    }
}
