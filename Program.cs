using System;

class Busquedas
{
    // Este es el método de búsqueda secuencial
    static int BusquedaSecuencial(int[] arreglo, int valor)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] == valor)
            {
                return i; // Acá retorna la posición
            }
        }
        return -1; // Y pues nos dice no encontrado
    }

    // Acá tenemos el otro método que es el de búsqueda binaria
    static int BusquedaBinaria(int[] arreglo, int valor)
    {
        int inicio = 0;
        int fin = arreglo.Length - 1;

        while (inicio <= fin)
        {
            int medio = (inicio + fin) / 2;

            if (arreglo[medio] == valor)
                return medio;
            else if (arreglo[medio] < valor)
                inicio = medio + 1;
            else
                fin = medio - 1;
        }

        return -1; // No encontrado
    }

    static void Main(string[] args)
    {
        int[] numeros = { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
        int buscar = 10;

        // Acá se realiza la búsqueda Secuencial
        int resultadoSecuencial = BusquedaSecuencial(numeros, buscar);
        if (resultadoSecuencial != -1)
            Console.WriteLine("Búsqueda Secuencial: Elemento encontrado en la posición " + resultadoSecuencial);
        else
            Console.WriteLine("Búsqueda Secuencial: Elemento no encontrado");

        // Búsqueda acá se realiza la búsqueda Binaria
        int resultadoBinaria = BusquedaBinaria(numeros, buscar);
        if (resultadoBinaria != -1)
            Console.WriteLine("Búsqueda Binaria: Elemento encontrado en la posición " + resultadoBinaria);
        else
            Console.WriteLine("Búsqueda Binaria: Elemento no encontrado");

        Console.ReadKey();
    }
}