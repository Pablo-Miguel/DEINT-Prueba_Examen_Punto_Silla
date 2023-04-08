using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_Prueba_Examen_Punto_Silla.Ejercicio1
{
    internal class Matriz
    {
        private int[ , ] matriz;
        private Boolean silla = false;
        public int filas { get; set; }
        public int columnas { get; set; }

        public Matriz()
        {
            
        }

        public void solicitarDimensiones() {
            try {

                solicitarFilas();

                solicitarColumnas();

                if (filas != null && columnas != null && filas != 0 && columnas != 0) {
                    matriz = new int[filas, columnas];

                    solicitarValores();

                    comprobarPuntoSilla();
                }

            } catch (FormatException) {
                Console.WriteLine("ERROR: No has metido un numero entero");
            }

        }

        private void comprobarPuntoSilla()
        {
            int minVal = matriz[0, 0];
            int maxVal = 0;

            int jFija = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] < minVal) { 
                        minVal = matriz[i, j];
                        jFija = j;
                    }
                }

                for (int k = 0; k < matriz.GetLength(0); k++)
                {
                    if (matriz[k, jFija] > maxVal)
                    {
                        maxVal = matriz[k, jFija];
                    }
                }

                if (minVal == maxVal)
                {
                    Console.WriteLine($"El punto de silla es el número en la posición [{i}] [{jFija}]: {minVal}");
                    silla = true;
                }

            }

            if (!silla) {
                Console.WriteLine("No hay punto de silla");
            }
        }

        private void solicitarValores()
        {
            for (int i = 0; i < matriz.GetLength(0); i++) {

                for (int j = 0; j < matriz.GetLength(1); j++){

                    Console.WriteLine($"Introduzca el valor para fila [{i}] y columna [{j}]: ");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    matriz[i, j] = temp;
                
                }
            }
            
        }

        private void solicitarFilas() {
            Console.WriteLine("Introduzca el número de filas: ");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp > 0)
            {
                filas = temp;
            }
            else
            {
                Console.WriteLine("ERROR: Numero de filas fuera de intervalo (1, n)");
            }
        }

        private void solicitarColumnas() {
            Console.WriteLine("Introduzca el número de columnas: ");
            int temp2 = Convert.ToInt32(Console.ReadLine());
            if (temp2 > 0)
            {
                columnas = temp2;
            }
            else
            {
                Console.WriteLine("ERROR: Numero de columnas fuera de intervalo (1, n)");
            }
        }
    }
}
