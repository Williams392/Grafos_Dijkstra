using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{
    class DJISKTRA
    {
        private int rango;
        private int[,] matriz;
        private string[] nodos;
        private int[] distancias;
        private bool[] visitados;

        public DJISKTRA(int[,] adyacencia, string[] vertices)
        {
            rango = vertices.Length;
            matriz = adyacencia;
            nodos = vertices;
            distancias = new int[rango];
            visitados = new bool[rango];

            for (int i = 0; i < rango; i++)
            {
                distancias[i] = int.MaxValue;
                visitados[i] = false;
            }
        }

        // En el metodo Privado -> NodoMinimo()
        private int NodoMinimo() 
        {
            int min = int.MaxValue;
            int minNodo = 0;

            for (int i = 0; i < rango; i++)
            {
                if (!visitados[i] && distancias[i] < min)
                {
                    min = distancias[i];
                    minNodo = i;
                }
            }

            return minNodo;
        }

        private int IndiceDeNodo(string nodo) // 
        {
            return Array.IndexOf(nodos, nodo);
        }

        public void MostrarRutaMatriz()
        {
            int f = 0;
            int c = 0;

            Console.ForegroundColor = ConsoleColor.Blue; // Imprecion del Encabezado -> Color Azul.

            for (f = 0; f < nodos.Length; f++)
            {
                Console.Write("\t{0}", nodos[f]); // tabulacion.
            }
            Console.WriteLine();

            for (f = 0; f < nodos.Length; f++)
            {
                Console.ForegroundColor = ConsoleColor.Blue; // el Encabezado -> Color Azul.
                Console.Write(nodos[f]);

                for (c = 0; c < nodos.Length; c++)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // el Encabezado -> Color Verde.
                    Console.Write("\t{0}", matriz[f, c]);
                }
                Console.WriteLine();
            }
        }

        public void Resolver(string vtcIni, string vtcFin) // 
        {
            int indiceInicio = IndiceDeNodo(vtcIni);
            int indiceFin = IndiceDeNodo(vtcFin);

            distancias[indiceInicio] = 0;

            for (int i = 0; i < rango - 1; i++)
            {
                int nodoActual = NodoMinimo();
                visitados[nodoActual] = true;

                for (int j = 0; j < rango; j++)
                {
                    int peso = matriz[nodoActual, j];
                    if (!visitados[j] && peso != 0 && distancias[nodoActual] != int.MaxValue && distancias[nodoActual] + peso < distancias[j])
                    {
                        distancias[j] = distancias[nodoActual] + peso;
                    }
                }
            }

            MostrarRuta(indiceInicio, indiceFin);
        }

        private void MostrarRuta(int vtcIni, int vtcFin) //
        {
            Console.WriteLine("\nRuta: ");

            int actual = vtcFin;
            List<string> ruta = new List<string>();
            ruta.Add(nodos[actual]);

            while (actual != vtcIni)
            {
                for (int i = 0; i < rango; i++)
                {
                    if (matriz[i, actual] != 0 && distancias[i] + matriz[i, actual] == distancias[actual])
                    {
                        actual = i;
                        ruta.Insert(0, nodos[actual]);
                        break;
                    }
                }
            }

            int peso = distancias[vtcFin];

            Console.WriteLine(string.Join(" -> ", ruta) + " (Peso: " + peso + ")");

        }

    }
}
