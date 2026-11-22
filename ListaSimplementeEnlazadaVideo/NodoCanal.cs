using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSimplementeEnlazadaVideo
{
    internal class NodoCanal
    {
        public string Nombre { get; set; }
        public string UrlStream { get; set; } // El dato ahora es la URL
        public NodoCanal Siguiente { get; set; }
        public NodoCanal Anterior { get; set; } //se agrega la linea para que el control pueda devolverse

        public NodoCanal(string nombre, string url)
        {
            Nombre = nombre;
            UrlStream = url;
            Siguiente = null;
            Anterior = null; // Inicializa el nodo anterior como null
        }

    }
}
