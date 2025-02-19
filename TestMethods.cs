using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        private static bool IsPrime(uint numero)
        {
            if (numero < 2) return false;
            for (uint i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        internal static uint StackFirstPrime(Stack<uint> pila)
        {
            foreach (uint numero in pila)
            {
                if (IsPrime(numero)) return numero;
            }
            return 0; // Si no hay primos
        }

        internal static Stack<uint> RemoveFirstPrime(Stack<uint> pila)
        {
            Stack<uint> pilaTemporal = new Stack<uint>();
            bool primoEliminado = false;

            while (pila.Count > 0)
            {
                uint numero = pila.Pop();
                if (!primoEliminado && IsPrime(numero))
                {
                    primoEliminado = true;
                    continue;
                }
                pilaTemporal.Push(numero);
            }

            // Restauramos el orden original
            Stack<uint> nuevaPila = new Stack<uint>();
            while (pilaTemporal.Count > 0)
            {
                nuevaPila.Push(pilaTemporal.Pop());
            }

            return nuevaPila;
        }

        internal static Queue<uint> CreateQueueFromStack(Stack<uint> pila)
        {
            Queue<uint> cola = new Queue<uint>();
            List<uint> listaElementos = new List<uint>(pila);

            foreach (var elemento in listaElementos)
            {
                cola.Enqueue(elemento);
            }

            return cola;
        }

        internal static List<uint> StackToList(Stack<uint> pila)
        {
            List<uint> lista = new List<uint>();
            Stack<uint> pilaTemporal = new Stack<uint>(pila);

            while (pilaTemporal.Count > 0)
            {
                lista.Add(pilaTemporal.Pop());
            }

            return lista;
        }

        internal static bool FoundElementAfterSorted(List<int> lista, int valor)
        {
            lista.Sort(); // Ordenamos antes de buscar

            int izquierda = 0, derecha = lista.Count - 1;
            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                if (lista[medio] == valor) return true;
                if (lista[medio] < valor)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }

            return false;
        }
    }
}
