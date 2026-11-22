using System.Drawing;

namespace WindowsFormsApp3
{
    internal class NodoImagen
    {
        public string RutaArchivo { get; set; } // Propiedad para almacenar la ruta del archivo
        public Image Imagen { get; set; }
        public NodoImagen Siguiente { get; set; }
        public NodoImagen Anterior { get; set; } // Puntero hacia atrás añadido

        public NodoImagen(string ruta)
        {
            Imagen = Image.FromFile(ruta);
            Siguiente = null;
            Anterior = null;
        }
    }
}