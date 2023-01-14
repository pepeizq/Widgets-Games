using Herramientas;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using System.Text.Json;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public class WidgetPrecarga
    {
        public void Cargar()
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.TextChanged += ActivarBotonCargaJuego;
            ObjetosVentana.tbWidgetPrecargaPequeña.TextChanged += ActivarBotonCargaJuego;
            ObjetosVentana.tbWidgetPrecargaGrande.TextChanged += ActivarBotonCargaJuego;

            ObjetosVentana.cbWidgetPrecargaImagen.SelectionChanged += CambiarImagenElegida;

            ObjetosVentana.botonWidgetPrecargaCargarJuego.Click += CargarJuego;
        }

        private void ActivarBotonCargaJuego(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaJuego();
        }

        private static void ActivarBotonCargaJuego()
        {
            bool activar1 = false;
            bool activar2 = false;
            bool activar3 = false;

            if (ObjetosVentana.tbWidgetPrecargaEjecutable.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim().Length > 0)
                {
                    activar1 = true;
                }
            }

            if (ObjetosVentana.tbWidgetPrecargaPequeña.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaPequeña.Text.Trim().Length > 0)
                {
                    activar2 = true;
                }
                else
                {
                    activar2 = false;
                }
            }
            else
            {
                activar2 = false;
            }

            if (ObjetosVentana.tbWidgetPrecargaGrande.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaGrande.Text.Trim().Length > 0)
                {
                    activar3 = true;
                }
                else
                {
                    activar3 = false;
                }
            }
            else
            {
                activar3 = false;
            }


            if (activar1 == true)
            {
                if (activar2 == true || activar3 == true)
                {
                    ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = true;
                }
                else
                {
                    ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = false;
                }               
            }
            else
            {
                ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = false;
            }
        }

        private void CambiarImagenElegida(object sender, SelectionChangedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                ObjetosVentana.tbWidgetPrecargaMensajeImagen.Text = recursos.GetString("ChooseImageSmall");
                
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaPequeña.Text;
                }
                catch { }
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                ObjetosVentana.tbWidgetPrecargaMensajeImagen.Text = recursos.GetString("ChooseImageBig");

                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaGrande.Text;
                }
                catch { }
            }
        }

        public static void PrecargarJuego(string nombre, string ejecutable, string imagenPequeña, string imagenMedianaGrande)
        {
            Pestañas.Visibilidad(ObjetosVentana.gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            ObjetosVentana.tbWidgetPrecargaTitulo.Text = nombre;
            ObjetosVentana.tbWidgetPrecargaEjecutable.Text = ejecutable;
            ObjetosVentana.tbWidgetPrecargaPequeña.Text = imagenPequeña;
            ObjetosVentana.tbWidgetPrecargaGrande.Text = imagenMedianaGrande;

            ActivarBotonCargaJuego();

            ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex = 0;
            ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaPequeña.Text;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex = 1;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex = 1;

            ObjetosVentana.tbWidgetCargarJuegoMensaje.Visibility = Visibility.Collapsed;
        }

        public void CargarJuego(object sender, RoutedEventArgs e)
        {
            ActivarDesactivar(false);

            string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Juego.json");

            Juego json = JsonSerializer.Deserialize<Juego>(plantilla);
            json.enlace = ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim();

            //------------------------------------------------

            string imagen = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaPequeña.Text.Trim();
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaGrande.Text.Trim();
            }

            json.fondo.url = imagen;

            //------------------------------------------------

            string horizontal = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 0) 
            {
                horizontal = "Left";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 1)
            {
                horizontal = "Center";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex == 2)
            {
                horizontal = "Right";
            }

            json.fondo.horizontal = horizontal;

            //------------------------------------------------

            string vertical = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 0)
            {
                vertical = "Top";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 1)
            {
                vertical = "Center";
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex == 2)
            {
                vertical = "Bottom";
            }

            json.fondo.vertical = vertical;

            //------------------------------------------------

            Ficheros.EscribirFichero("Juego.json", JsonSerializer.Serialize(json));

            ObjetosVentana.tbWidgetCargarJuegoMensaje.Visibility = Visibility.Visible;
            ResourceLoader recursos = new ResourceLoader();
            ObjetosVentana.tbWidgetCargarJuegoMensaje.Text = recursos.GetString("WidgetLoadGameMessage");

            ActivarDesactivar(true);
        }

        private void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaPequeña.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaGrande.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagen.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.IsEnabled = estado;
        }
    }
}
