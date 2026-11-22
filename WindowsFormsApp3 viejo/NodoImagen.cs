using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class NodoImagen
    {
        // El 'Data' es un objeto Image de Windows Forms
        public Image Imagen { get; set; }
        public NodoImagen Siguiente { get; set; }

        public NodoImagen(string ruta)
        {
            // Carga la imagen desde la ruta del archivo
            Imagen = Image.FromFile(ruta);
            Siguiente = null;
        }
    }
}
