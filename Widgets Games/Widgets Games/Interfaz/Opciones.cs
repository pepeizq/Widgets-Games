using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppLifecycle;
using System;
using System.Collections.Generic;
using Windows.Globalization;
using Windows.Storage;
using Windows.System.UserProfile;
using WinRT.Interop;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public static class Opciones
    {
        public static void CargarDatos()
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

            IReadOnlyList<string> idiomasApp = ApplicationLanguages.ManifestLanguages;

            foreach (var idioma in idiomasApp)
            {
                ObjetosVentana.cbOpcionesIdioma.Items.Add(idioma);
            }

            if (datos.Values["OpcionesIdioma"] == null)
            {
                IReadOnlyList<string> idiomasUsuario = GlobalizationPreferences.Languages;
                bool seleccionado = false;

                foreach (var idioma in idiomasUsuario)
                {
                    foreach (var idioma2 in idiomasApp)
                    {
                        if (idioma2 == idioma)
                        {
                            ObjetosVentana.cbOpcionesIdioma.SelectedItem = idioma2;
                            seleccionado = true;
                        }
                    }
                }

                if (seleccionado == false)
                {
                    ObjetosVentana.cbOpcionesIdioma.SelectedIndex = 0;
                }

                datos.Values["OpcionesIdioma"] = ObjetosVentana.cbOpcionesIdioma.SelectedItem;
            }
            else
            {
                ObjetosVentana.cbOpcionesIdioma.SelectedItem = datos.Values["OpcionesIdioma"];
            }

            ApplicationLanguages.PrimaryLanguageOverride = ObjetosVentana.cbOpcionesIdioma.SelectedItem.ToString();
            ObjetosVentana.cbOpcionesIdioma.SelectionChanged += CbOpcionIdioma;

            ////---------------------------------

            //if (ObjetosVentana.toggleOpcionesNotificaciones.IsEnabled == true)
            //{
            //    if (datos.Values["OpcionesNotificaciones"] == null)
            //    {
            //        datos.Values["OpcionesNotificaciones"] = true;
            //    }

            //    ObjetosVentana.toggleOpcionesNotificaciones.Toggled += ToggleOpcionNotificaciones;

            //    if (datos.Values["OpcionesNotificaciones"] is true)
            //    {
            //        ObjetosVentana.toggleOpcionesNotificaciones.IsOn = true;
            //    }
            //    else
            //    {
            //        ObjetosVentana.toggleOpcionesNotificaciones.IsOn = false;
            //    }
            //}

            ////---------------------------------

            //if (datos.Values["OpcionesAnuncios"] == null)
            //{
            //    datos.Values["OpcionesAnuncios"] = true;
            //}

            //ObjetosVentana.toggleOpcionesAnuncios.Toggled += ToggleOpcionAnuncios;

            //if (datos.Values["OpcionesAnuncios"] is true)
            //{
            //    ObjetosVentana.toggleOpcionesAnuncios.IsOn = true;
            //}
            //else
            //{
            //    ObjetosVentana.toggleOpcionesAnuncios.IsOn = false;
            //}

            ////---------------------------------

            //if (datos.Values["OpcionesMensajes"] == null)
            //{
            //    datos.Values["OpcionesMensajes"] = true;
            //}

            //ObjetosVentana.toggleOpcionesMensajes.Toggled += ToggleOpcionMensajes;

            //if (datos.Values["OpcionesMensajes"] is true)
            //{
            //    ObjetosVentana.toggleOpcionesMensajes.IsOn = true;
            //}
            //else
            //{
            //    ObjetosVentana.toggleOpcionesMensajes.IsOn = false;
            //}

            ////---------------------------------

            if (datos.Values["OpcionesPantalla"] == null)
            {
                datos.Values["OpcionesPantalla"] = 0;
            }

            ObjetosVentana.cbOpcionesPantalla.SelectionChanged += CbOpcionPantalla;
            ObjetosVentana.cbOpcionesPantalla.SelectedIndex = (int)datos.Values["OpcionesPantalla"];

            ////---------------------------------

            //ObjetosVentana.botonOpcionesActualizar.Click += BotonOpcionActualizar;
            ObjetosVentana.botonOpcionesLimpiar.Click += BotonOpcionLimpiar;
        }

        public static void CbOpcionIdioma(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesIdioma"] = cb.SelectedItem;

            ApplicationLanguages.PrimaryLanguageOverride = datos.Values["OpcionesIdioma"].ToString();
        }

        //public static void ToggleOpcionNotificaciones(object sender, RoutedEventArgs e)
        //{
        //    ToggleSwitch toggle = sender as ToggleSwitch;

        //    ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
        //    datos.Values["OpcionesNotificaciones"] = toggle.IsOn;

        //    if (toggle.IsOn == true)
        //    {
        //        Push.Escuchar();
        //    }
        //    else
        //    {
        //        Push.Parar();
        //    }
        //}

        //public static void ToggleOpcionAnuncios(object sender, RoutedEventArgs e)
        //{
        //    ToggleSwitch toggle = sender as ToggleSwitch;

        //    ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
        //    datos.Values["OpcionesAnuncios"] = toggle.IsOn;
        //}

        //public static void ToggleOpcionMensajes(object sender, RoutedEventArgs e)
        //{
        //    ToggleSwitch toggle = sender as ToggleSwitch;

        //    ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
        //    datos.Values["OpcionesMensajes"] = toggle.IsOn;
        //}

        //public static void BotonOpcionActualizar(object sender, RoutedEventArgs e)
        //{
        //    BarraTitulo.CambiarTitulo(null);
        //    Wordpress.Cargar();
        //}

        public static void CbOpcionPantalla(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesPantalla"] = cb.SelectedIndex;

            IntPtr ventanaInt = WindowNative.GetWindowHandle(ObjetosVentana.ventana);
            WindowId ventanaID = Win32Interop.GetWindowIdFromWindow(ventanaInt);
            AppWindow ventana2 = AppWindow.GetFromWindowId(ventanaID);

            if (cb.SelectedIndex == 0)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.Default);
            }
            else if (cb.SelectedIndex == 1)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.FullScreen);
            }
            else if (cb.SelectedIndex == 2)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.Overlapped);
            }
        }

        public static async void BotonOpcionLimpiar(object sender, RoutedEventArgs e)
        {
            await ApplicationData.Current.ClearAsync();
            AppInstance.Restart(null);
        }
    }
}
