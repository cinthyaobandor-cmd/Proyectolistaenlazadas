using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSimplementeEnlazadaVideo
{
    
    internal class ListaSimpleEnlazadaCanales
    {
        private NodoCanal Cabeza { get; set; }
        private NodoCanal actual;

        public ListaSimpleEnlazadaCanales()
        {
            Cabeza = null;
            actual = null;
        }
        // Método para agregar un nuevo canal
        public void AgregarCanal(string nombre, string url)
        {
            NodoCanal nuevoNodo = new NodoCanal(nombre, url);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                actual = Cabeza;
                return;
            }

            NodoCanal temp = Cabeza;
            while (temp.Siguiente != null)
            {
                temp = temp.Siguiente;
            }
            temp.Siguiente = nuevoNodo;
        }

        // Obtiene el nodo actual (para la reproducción inicial o después de reiniciar)
        public NodoCanal ObtenerCanalActual()
        {
            return actual;
        }

        // Avanza al siguiente canal y lo devuelve
        public NodoCanal ObtenerSiguienteCanal()
        {
            // Si hay un siguiente nodo, avanza el puntero 'actual'
            if (actual?.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            // Si no hay siguiente, se queda en el último nodo
            return actual;
        }

        // Vuelve al primer canal de la lista
        public void Reiniciar()
        {
            actual = Cabeza;
        }

    }
}
