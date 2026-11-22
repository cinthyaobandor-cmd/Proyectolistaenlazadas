using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaSimplementeEnlazadaVideo
{
    public partial class Form1 : Form
    {
        private ListaSimpleEnlazadaCanales galeriaCanales;
        public Form1()
        {
            InitializeComponent();
            InicializarCanales();
        }

        private void InicializarCanales()
        {
            galeriaCanales = new ListaSimpleEnlazadaCanales();

            // ⚠️ IMPORTANTE: El control AxWindowsMediaPlayer funciona mejor con streams 
            // directos (archivos MP4/WMV/M3U8 simples) o streams RTP. 
            // Las URLs directas de YouTube o Twitch NO funcionarán aquí, ya que necesitan 
            // un navegador o un reproductor más avanzado para interpretar el protocolo HLS.

            // 💡 Ejemplos de streams públicos que puedes usar para pruebas (Generalmente son demos):

            // 1. Big Buck Bunny (ya incluido en la respuesta anterior)
            galeriaCanales.AgregarCanal("Big Buck Bunny (Demo)",
                "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");

            // 2. Tears of Steel
            galeriaCanales.AgregarCanal("Tears of Steel (Demo)",
                "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/TearsOfSteel.mp4");

            // 3. 🐘 Canal 4 (Elephants Dream) - NUEVO
            galeriaCanales.AgregarCanal("Canal 4 (Elefantes)",
                "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4");

            // 4. 🐉 Canal 5 (Sintel) - NUEVO
            galeriaCanales.AgregarCanal("Canal 5 (Sintel)",
                "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4");

            // 5. 💧 Canal 6 (Lluvia) - NUEVO
            galeriaCanales.AgregarCanal("Canal 6 (Lluvia)",
                "http://techslides.com/demos/sample-videos/small.mp4");

            // --- Canales Ficticios (Para demostrar el concepto de un "Canal en Vivo") ---

            // 6. 📰 Canal 7 (Noticias Ficticias) - NUEVO
            // Nota: Estas URLs deben ser reemplazadas por un stream HLS/RTMP real si lo obtienes.
            galeriaCanales.AgregarCanal("Canal 7 (Noticias Ficticias)",
                "https://fake-news-stream.com/live/ch7.m3u8");

            // 7. ⚽ Canal 8 (Deportes Ficticios) - NUEVO
            galeriaCanales.AgregarCanal("Canal 8 (Deportes Ficticios)",
                "https://sports-live-stream.com/hd/ch8.ts");

            // Iniciar con el primer canal
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void ReproducirCanal(NodoCanal canal)
        {
            if (canal != null)
            {
                // 1. Mostrar el nombre del canal
                lblNombreCanal.Text = $"🔴 En Vivo: {canal.Nombre}";

                // 2. Cargar y reproducir el stream en el AxWindowsMediaPlayer
                // La propiedad URL es la clave para iniciar la reproducción.
                axWindowsMediaPlayer1.URL = canal.UrlStream;
            }
            else
            {
                lblNombreCanal.Text = "FIN DE LA LISTA DE CANALES";
                axWindowsMediaPlayer1.URL = string.Empty; // Detener la reproducción
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Pide a la lista enlazada que avance su puntero al siguiente nodo
            NodoCanal siguienteCanal = galeriaCanales.ObtenerSiguienteCanal();

            // Actualiza la visualización
            ReproducirCanal(siguienteCanal);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Vuelve al primer nodo y actualiza la visualización
            galeriaCanales.Reiniciar();
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NodoCanal canalAnterior = galeriaCanales.ObtenerCanalAnterior();
            ReproducirCanal(canalAnterior);
        }
    }
}
