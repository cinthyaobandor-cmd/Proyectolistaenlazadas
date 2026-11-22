using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace ListaEnlazadaImagenes
{
    public partial class FormPrincipal : Form
    {
        private ListaSimpleEnlazada galeriaImagenes;
        public FormPrincipal()
        {
            InitializeComponent();
            // 1. Inicializar la lista enlazada y cargar imágenes al inicio.
            InicializarGaleria();
        }

        private void InicializarGaleria()
        {
            galeriaImagenes = new ListaSimpleEnlazada();

              galeriaImagenes.AgregarImagen(@"C:\Users\CURLING\source\repos\WindowsFormsApp3\WindowsFormsApp3\Imagenes\android.png");
              galeriaImagenes.AgregarImagen(@"C:\Users\CURLING\source\repos\WindowsFormsApp3\WindowsFormsApp3\Imagenes\androidchocolate.png");
              galeriaImagenes.AgregarImagen(@"C:\Users\CURLING\source\repos\WindowsFormsApp3\WindowsFormsApp3\Imagenes\androidcupcake.png");
              galeriaImagenes.AgregarImagen(@"C:\Users\CURLING\source\repos\WindowsFormsApp3\WindowsFormsApp3\Imagenes\AVO1.png");
            // Mostrar la primera imagen al cargar el formulario
            ActualizarPictureBox(galeriaImagenes.ObtenerImagenActual());
        }

        // Función de utilidad para actualizar el PictureBox
        private void ActualizarPictureBox(Image img)
        {
            if (img != null)
            {
                pictureBoxImagen.Image = img;
            }
        }
      

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Esto llama al método de la lista enlazada que avanza el puntero interno
            Image siguienteImg = galeriaImagenes.ObtenerSiguienteImagen();

            // Actualiza la UI
            ActualizarPictureBox(siguienteImg);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Esto llama al método de la lista enlazada que resetea el puntero 'actual' a 'Cabeza'
            galeriaImagenes.Reiniciar();

            // Actualiza la UI con la imagen de la Cabeza
            ActualizarPictureBox(galeriaImagenes.ObtenerImagenActual());
        }
    }
}
