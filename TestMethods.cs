using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        //   Función auxiliar para verificar si un número es primo
        private static bool IsPrime(uint num)
        {
            if (num < 2) return false;
            for (uint i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        //  Punto 1.  Inciso a.  Encontrar el primer número primo en la pila
        internal static uint StackFirstPrime(Stack<uint> stack)
        {
            foreach (uint num in stack)
            {
                if (IsPrime(num))
                    return num; // Retorna el primer primo encontrado
            }
            return 0; // No hay primos en la pila
        }

        //  Punto 1. Inciso b.  Eliminar el primer número primo encontrado en la pila
        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
            Stack<uint> aux = new Stack<uint>();
            bool removed = false;

            while (stack.Count > 0)
            {
                uint num = stack.Pop();
                if (!removed && IsPrime(num))
                {
                    removed = true; // Marcamos que lo eliminamos y continuamos sin agregarlo
                    continue;
                }
                aux.Push(num);
            }

            // Reconstruimos la pila original con el orden correcto
            Stack<uint> newStack = new Stack<uint>();
            while (aux.Count > 0)
            {
                newStack.Push(aux.Pop());
            }

            return newStack;
        }

        //  Punto 1. Inciso c. crear una cola a partir de los elementos de la pila respetando el orden dela pila
        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            Queue<uint> queue = new Queue<uint>();
            List<uint> list = new List<uint>(stack); // Copia los elementos sin alterar el orden

            foreach (var item in list) // La lista mantiene el orden original
            {
                queue.Enqueue(item);
            }

            return queue;
        }

        //  Punto 1. Inciso d. Convierte la pila en una lista, respetando el orden de la pila
        internal static List<uint> StackToList(Stack<uint> stack)
        {
            List<uint> list = new List<uint>();
            Stack<uint> aux = new Stack<uint>(stack); // Copia de la pila

            while (aux.Count > 0)
            {
                list.Add(aux.Pop());
            }

            return list;
        }

        /* 
         * Numeral 2. Se tiene una lista de tamaño arbitrario y par, llena con números enteros al azar; cada uno inferior a 100.
         * Determinar si un número se encuentra entre los elementos de la lista, tras ordenarla ascendentemente
         */
        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
            // Ordenar la lista en orden ascendente
            list.Sort();

            // Búsqueda binaria para encontrar el valor
            int left = 0, right = list.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] == value)
                    return true;
                if (list[mid] < value)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false; // No encontrado;
        }
    }
}