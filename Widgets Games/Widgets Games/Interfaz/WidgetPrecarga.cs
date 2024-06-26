﻿using Herramientas;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using System;
using System.Text.Json;
using Windows.System;
using Windows.UI;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public class WidgetPrecarga
    {
        public static void Cargar()
        {
            int i = 0;
            foreach (object boton in ObjetosVentana.spWidgetPrecargaBotones.Children)
            {
                if (boton.GetType() == typeof(Button2))
                {
                    Button2 boton2 = (Button2)boton;

                    boton2.Tag = i;
                    boton2.Click += CambiarPestaña;
                    boton2.PointerEntered += Animaciones.EntraRatonBoton2;
                    boton2.PointerExited += Animaciones.SaleRatonBoton2;

                    i += 1;
                }
            }

            //---------------------------------

            ObjetosVentana.tbWidgetPrecargaEjecutable.TextChanged += ActivarBotonCargaJuego;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            //---------------------------------

            ObjetosVentana.cbWidgetPrecargaImagen.SelectionChanged += CambiarImagenElegida;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagen.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;

            //---------------------------------

            ObjetosVentana.botonWidgetPrecargaCargarJuego.Click += CargarJuego;
            ObjetosVentana.botonWidgetPrecargaCargarJuego.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonWidgetPrecargaCargarJuego.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.Click += AbrirAyuda;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void CambiarPestaña(object sender, RoutedEventArgs e)
        {
            Button2 botonPulsado = sender as Button2;
            int pestañaMostrar = (int)botonPulsado.Tag;
            CambiarPestaña(pestañaMostrar);
        }

        private static void CambiarPestaña(int botonPulsado)
        {
            SolidColorBrush colorPulsado = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
            colorPulsado.Opacity = 0.6;

            int i = 0;
            foreach (object boton in ObjetosVentana.spWidgetPrecargaBotones.Children)
            {
                if (boton.GetType() == typeof(Button2))
                {
                    Button2 boton2 = (Button2)boton;

                    if (i == botonPulsado)
                    {
                        boton2.Background = colorPulsado;
                    }
                    else
                    {
                        boton2.Background = new SolidColorBrush(Colors.Transparent);
                    }

                    i += 1;
                }
            }

            foreach (StackPanel sp in ObjetosVentana.spWidgetPrecargaPestañas.Children)
            {
                sp.Visibility = Visibility.Collapsed;
            }

            StackPanel spMostrar = ObjetosVentana.spWidgetPrecargaPestañas.Children[botonPulsado] as StackPanel;
            spMostrar.Visibility = Visibility.Visible;
        }

        private static void ActivarBotonCargaJuego(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaJuego();

            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0)
            {
                if (ComprobarURI(tb.Text.Trim()) == true)
                {
                    ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Visible;
            }
        }

        private static void ActualizarImagenPequeña(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaJuego();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
            }
        }

        private static void ActualizarImagenGrande(object sender, TextChangedEventArgs e)
        {
            ActivarBotonCargaJuego();

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
            }
        }

        private static async void ActivarBotonCargaJuego()
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

            if (ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text.Trim().Length > 0)
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

            if (ObjetosVentana.tbWidgetPrecargaImagenGrande.Text != null)
            {
                if (ObjetosVentana.tbWidgetPrecargaImagenGrande.Text.Trim().Length > 0)
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

            //-----------------------------------------------------

            //if (ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled == true)
            //{
            //    if (await Trial.Detectar() == true)
            //    {
            //        if (await Ficheros.LeerCantidadFicheros() < 1)
            //        {
            //            ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = true;
            //        }
            //        else
            //        {
            //            ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = false;
            //        }
            //    }
            //}
        }

        private static void CambiarImagenElegida(object sender, SelectionChangedEventArgs e)
        {
            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
                }
                catch { }
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                try
                {
                    ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
                }
                catch { }
            }
        }

        public static void PrecargarJuego(string nombre, string ejecutable, string argumentos, string imagenPequeña, string imagenMedianaGrande)
        {
            Pestañas.Visibilidad(ObjetosVentana.gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            if (nombre != null)
            {
                CambiarPestaña(1);
                ObjetosVentana.tbWidgetPrecargaTitulo.Text = nombre;
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Visible;
            }
            else
            {
                CambiarPestaña(0);
                ObjetosVentana.tbWidgetPrecargaTitulo.Visibility = Visibility.Collapsed;
            }

            ObjetosVentana.tbWidgetPrecargaEjecutable.Text = ejecutable;

            if (ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim().Length > 0)
            {
                if (ComprobarURI(ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim()) == true)
                {
                    ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ObjetosVentana.spWidgetPrecargaArgumentosSeccion.Visibility = Visibility.Visible;
            }

            ObjetosVentana.tbWidgetPrecargaArgumentos.Text = argumentos;

            if (imagenPequeña != null)
            {
                ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text = imagenPequeña.Trim();
            }
            else
            {
                ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text = null;
            }

            if (imagenMedianaGrande != null)
            {
                ObjetosVentana.tbWidgetPrecargaImagenGrande.Text = imagenMedianaGrande.Trim();
            }
            else
            {
                ObjetosVentana.tbWidgetPrecargaImagenGrande.Text = null;
            }

            ActivarBotonCargaJuego();

            if (imagenPequeña == string.Empty && imagenMedianaGrande != string.Empty)
            {
                ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex = 1;
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text;
            }
            else
            {
                ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex = 0;
                ObjetosVentana.imagenWidgetPrecargaElegida.Source = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text;
            }           

            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.SelectedIndex = 1;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.SelectedIndex = 1;

            ObjetosVentana.tbWidgetCargarJuegoMensaje.Visibility = Visibility.Collapsed;
        }

        public static void CargarJuego(object sender, RoutedEventArgs e)
        {
            ActivarDesactivar(false);

            string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Juego.json");

            Juego json = JsonSerializer.Deserialize<Juego>(plantilla);
            json.enlace = ObjetosVentana.tbWidgetPrecargaEjecutable.Text.Trim();

            if (ObjetosVentana.tbWidgetPrecargaArgumentos.Text.Trim().Length > 0)
            {
                json.argumentos = ObjetosVentana.tbWidgetPrecargaArgumentos.Text.Trim();
            }
            
            //------------------------------------------------

            string imagen = string.Empty;

            if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 0)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaImagenPequeña.Text.Trim();
            }
            else if (ObjetosVentana.cbWidgetPrecargaImagen.SelectedIndex == 1)
            {
                imagen = ObjetosVentana.tbWidgetPrecargaImagenGrande.Text.Trim();
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

            ActivarBotonCargaJuego();

            ActivarDesactivar(true);
        }

        public static bool ComprobarURI(string enlace)
        {
            bool enlaceURI = false;

            if (enlace.Contains("steam://rungameid/") == true || enlace.Contains("uplay://launch/") == true ||
                enlace.Contains("amazon-games://play/") == true || enlace.Contains("com.epicgames.launcher://apps/") == true)
            {
                enlaceURI = true;
            }

            return enlaceURI;
        }

        private static async void AbrirAyuda(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/app/widgets-for-games/#guide"));
        }

        private static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.tbWidgetPrecargaEjecutable.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaArgumentos.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña.IsEnabled = estado;
            ObjetosVentana.tbWidgetPrecargaImagenGrande.IsEnabled = estado;

            ObjetosVentana.cbWidgetPrecargaImagen.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal.IsEnabled = estado;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical.IsEnabled = estado;

            ObjetosVentana.botonWidgetPrecargaCargarJuego.IsEnabled = estado;
            ObjetosVentana.botonWidgetPrecargaAbrirAyuda.IsEnabled = estado;
        }
    }
}
