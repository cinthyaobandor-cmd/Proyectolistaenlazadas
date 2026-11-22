using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApp3;

namespace ListaEnlazadalimagenes
{
    public class ListaSimpleEnlazada
    {
        private NodoImagen cabeza;
        private NodoImagen actual;
        private int total;
        private int indiceActual;

        public int Total => total;
        public int IndiceActual => indiceActual;

        public ListaSimpleEnlazada()
        {
            cabeza = null;
            actual = null;
            total = 0;
            indiceActual = 0;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        public void AgregarImagen(string ruta)
        {
            NodoImagen nuevoNodo = new NodoImagen(ruta);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cabeza.Siguiente = cabeza; // Circular
                actual = cabeza;
                indiceActual = 1;
            }
            else
            {
                NodoImagen ultimo = cabeza;
                while (ultimo.Siguiente != cabeza)
                {
                    ultimo = ultimo.Siguiente;
                }
                ultimo.Siguiente = nuevoNodo;
                nuevoNodo.Siguiente = cabeza;
            }
            total++;
        }

        public Image ObtenerImagenActual()
        {
            if (actual != null)
            {
                return actual.Imagen;
            }
            return null;
        }

        public void ObtenerSiguienteImagen()
        {
            if (actual != null)
            {
                actual = actual.Siguiente;
                indiceActual = (indiceActual % total) + 1;
            }
        }

        public void ObtenerAnteriorImagen()
        {
            if (actual != null && cabeza != null)
            {
                NodoImagen temp = cabeza;
                while (temp.Siguiente != actual)
                {
                    temp = temp.Siguiente;
                }
                actual = temp;
                indiceActual = (indiceActual - 2 + total) % total + 1;
            }
        }

        public void Reiniciar()
        {
            if (cabeza != null)
            {
                actual = cabeza;
                indiceActual = 1;
            }
            else
            {
                indiceActual = 0;
            }
        }

        public void EliminarActual()
        {
            if (cabeza == null) return;

            if (cabeza.Siguiente == cabeza && total == 1)
            {
                cabeza = null;
                actual = null;
                total = 0;
                indiceActual = 0;
                return;
            }

            NodoImagen anterior = cabeza;
            while (anterior.Siguiente != actual)
            {
                anterior = anterior.Siguiente;
            }

            if (actual == cabeza)
            {
                cabeza = cabeza.Siguiente;
            }

            anterior.Siguiente = actual.Siguiente;
            actual = actual.Siguiente;
            total--;

            if (total > 0)
            {
                indiceActual = (indiceActual > total) ? 1 : indiceActual;
            }
            else
            {
                indiceActual = 0;
            }
        }

        public string[] ObtenerTodasLasRutas()
        {
            List<string> listaRutas = new List<string>();

            if (cabeza == null) return listaRutas.ToArray();

            NodoImagen nodoTemp = cabeza;
            do
            {
                if (nodoTemp != null && !string.IsNullOrEmpty(nodoTemp.RutaArchivo))
                {
                    listaRutas.Add(nodoTemp.RutaArchivo);
                }
                nodoTemp = nodoTemp.Siguiente;
            } while (nodoTemp != null && nodoTemp != cabeza);

            return listaRutas.ToArray();
        }
    }
}