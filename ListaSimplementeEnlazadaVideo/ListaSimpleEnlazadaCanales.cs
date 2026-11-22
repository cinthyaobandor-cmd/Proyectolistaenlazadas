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
                nuevoNodo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior  = nuevoNodo; // El nodo apunta a sí mismo como anterior

                Cabeza = nuevoNodo;
                actual = Cabeza;
                return;
            }
            NodoCanal ultimo = Cabeza.Anterior; // El último nodo es el anterior de la cabeza
            ultimo.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = ultimo;
            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo; // Actualiza el nodo anterior de la cabeza
        }

        // Obtiene el nodo actual (para la reproducción inicial o después de reiniciar)
        public NodoCanal ObtenerCanalActual()
        {
            return actual;
        }

        // Avanza al siguiente canal y lo devuelve
        public NodoCanal ObtenerSiguienteCanal()
        {
            // Si la lista no esta vacía, avanza al siguiente 
            if (actual!= null)
            {
                actual = actual.Siguiente;
            }
            // Si la lista es circular, del ultimo pasa al primero 
            return actual;
        }
        public NodoCanal ObtenerCanalAnterior()
   
        {
            // Si la lista no esta vacía, retrocede al anterior 
            if (actual != null)
            {
                actual = actual.Anterior;
            }
            // Si la lista es circular, del primero pasa al ultimo 
            return actual;
        }

        // Vuelve al primer canal de la lista
        public void Reiniciar()
        {
            actual = Cabeza;
        }

    }
}
