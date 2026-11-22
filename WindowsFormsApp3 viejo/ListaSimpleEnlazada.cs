using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class ListaSimpleEnlazada
    {
        private NodoImagen Cabeza { get; set; }
        private NodoImagen actual; // Puntero de navegación

        public ListaSimpleEnlazada()
        {
            Cabeza = null;
            actual = null;
        }

        // 💡 Método para agregar una imagen a la lista
        public void AgregarImagen(string ruta)
        {
            NodoImagen nuevoNodo = new NodoImagen(ruta);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                actual = Cabeza; // El primer nodo es el actual
                return;
            }

            NodoImagen temp = Cabeza;
            while (temp.Siguiente != null)
            {
                temp = temp.Siguiente;
            }
            temp.Siguiente = nuevoNodo;
        }

        // 💡 Método clave: Avanza al siguiente nodo y devuelve su imagen
        public Image ObtenerSiguienteImagen()
        {
            if (actual == null)
            {
                return null; // Lista vacía
            }

            // Si hay un siguiente nodo, avanza el puntero 'actual'
            if (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            // Si no hay siguiente, se queda en el último nodo

            return actual.Imagen;
        }

        // 💡 Método para obtener la imagen en la posición inicial
        public Image ObtenerImagenActual()
        {
            return actual?.Imagen;
        }

        // 💡 Método para resetear la posición 'actual'
        public void Reiniciar()
        {
            actual = Cabeza;
        }
    }
}