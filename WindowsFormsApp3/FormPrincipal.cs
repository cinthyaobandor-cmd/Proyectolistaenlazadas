using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ListaEnlazadalimagenes;

namespace ListaEnlazadaImagenes
{
    public partial class FormPrincipal : Form
    {
        private ListaSimpleEnlazada galeriaImagenes;

        // Archivo de texto donde se guardarán las rutas de forma permanente
        private string archivoRutas = "rutas_galeria.txt";

        public FormPrincipal()
        {
            InitializeComponent();

            // 1. Inicializamos la instancia de la lista una sola vez
            galeriaImagenes = new ListaSimpleEnlazada();

            // 2. Cargamos las imágenes (desde el archivo guardado o las por defecto) y actualizamos la pantalla
            InicializarGaleria();
        }

        private void InicializarGaleria()
        {
            // Si ya existe el archivo con rutas guardadas de ejecuciones anteriores, las cargamos
            if (File.Exists(archivoRutas))
            {
                string[] rutasGuardadas = File.ReadAllLines(archivoRutas);
                foreach (string ruta in rutasGuardadas)
                {
                    if (File.Exists(ruta))
                    {
                        galeriaImagenes.AgregarImagen(ruta);
                    }
                }
            }
            else
            {
                // Si es la primera vez que se abre el programa, cargamos las imágenes por defecto y creamos el archivo
                string[] rutasIniciales = new string[]
                {
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 1.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 2.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 3.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 4.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 5.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 6.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 7.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 8.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 9.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 10.png",
                    @"C:\Users\Jason\Desktop\Proyecto II\EJercicioListaEnlazadas-Video-Imagenes-master\WindowsFormsApp3\Imagenes\Imagen 11.png",
                };

                foreach (string ruta in rutasIniciales)
                {
                    if (File.Exists(ruta))
                    {
                        galeriaImagenes.AgregarImagen(ruta);
                    }
                }

                // Guardamos las rutas iniciales en el archivo de texto
                File.WriteAllLines(archivoRutas, rutasIniciales);
            }

            // Forzamos que inicie en la primera posición
            galeriaImagenes.Reiniciar();

            ActualizarInterfaz();
        }

        // Actualiza tanto el PictureBox como el Label del contador
        private void ActualizarInterfaz()
        {
            Image imgActual = galeriaImagenes.ObtenerImagenActual();

            if (imgActual != null)
            {
                pictureBoxImagen.Image = imgActual;
            }
            else
            {
                pictureBoxImagen.Image = null;
            }

            if (galeriaImagenes.Total > 0)
            {
                lblContador.Text = $"Imagen {galeriaImagenes.IndiceActual} de {galeriaImagenes.Total}";
            }
            else
            {
                lblContador.Text = "Imagen 0 de 0";
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Enlace seguro de eventos por código para garantizar que los botones funcionen al hacer clic
            btnAnterior.Click -= btnAnterior_Click;
            btnAnterior.Click += btnAnterior_Click;

            btnReiniciar.Click -= btnReiniciar_Click;
            btnReiniciar.Click += btnReiniciar_Click;

            btnSiguiente.Click -= btnSiguiente_Click;
            btnSiguiente.Click += btnSiguiente_Click;

            btnAgregar.Click -= btnAgregarImagen_Click;
            btnAgregar.Click += btnAgregarImagen_Click;

            btnEliminar.Click -= btnEliminarImagen_Click;
            btnEliminar.Click += btnEliminarImagen_Click;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            galeriaImagenes.ObtenerAnteriorImagen();
            ActualizarInterfaz();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            galeriaImagenes.Reiniciar();
            ActualizarInterfaz();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            galeriaImagenes.ObtenerSiguienteImagen();
            ActualizarInterfaz();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        galeriaImagenes.AgregarImagen(file);
                    }

                    // Agrega las nuevas rutas seleccionadas al archivo de texto permanente
                    File.AppendAllLines(archivoRutas, openFileDialog.FileNames);

                    ActualizarInterfaz();
                    MessageBox.Show("Imágenes agregadas y guardadas permanentemente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (galeriaImagenes.EstaVacia())
            {
                MessageBox.Show("No hay imágenes para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Elimina la imagen actual de la lista enlazada
            galeriaImagenes.EliminarActual();

            // 2. Obtiene las rutas restantes y actualiza/sobrescribe el archivo de texto
            string[] rutasActualizadas = galeriaImagenes.ObtenerTodasLasRutas();
            File.WriteAllLines(archivoRutas, rutasActualizadas);

            // 3. Refresca la interfaz
            ActualizarInterfaz();

            MessageBox.Show("Imagen eliminada de la lista y del registro permanente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}