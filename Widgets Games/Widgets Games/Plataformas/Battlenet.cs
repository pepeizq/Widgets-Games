﻿using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI;
using static Widgets_Games.MainWindow;

namespace Plataformas
{
    public static class Battlenet
    {
        public static void Cargar()
        {
            ObjetosVentana.botonBattlenetCerrarMensajeSiJuegos.Click += CerrarMensajeSiJuegosClick;
            ObjetosVentana.botonBattlenetCerrarMensajeSiJuegos.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonBattlenetCerrarMensajeSiJuegos.PointerExited += Animaciones.SaleRatonBoton2;
        }

        public static async void CargarJuegosInstalados()
        {
            ObjetosVentana.gridBattlenetMensajeSiJuegos.Visibility = Visibility.Collapsed;
            ObjetosVentana.prBattlenetJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gvBattlenetJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Collapsed;

            List<BattlenetJuego> listaJuegos = new List<BattlenetJuego>();

            RegistryKey registro = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Blizzard Entertainment\\Battle.net\\Capabilities");
            
            if (registro != null) 
            {
                string rutaEjecutable = registro.GetValue("ApplicationIcon").ToString();

                if (rutaEjecutable != null)
                {
                    rutaEjecutable = rutaEjecutable.Replace(Strings.ChrW(34).ToString(), null);
                    rutaEjecutable = rutaEjecutable.Remove(rutaEjecutable.Length - 2, 2);

                    string bbdd = await Decompiladores.CogerHtml("https://raw.githubusercontent.com/pepeizq/Database-Games/master/Base%20de%20Datos%20Plataformas/Jsons/Battlenet.json");

                    if (bbdd != null)
                    {
                        List<BattlenetAPI> json = JsonConvert.DeserializeObject<List<BattlenetAPI>>(bbdd);

                        if (json != null)
                        {
                            if (json.Count > 0)
                            {
                                foreach (BattlenetAPI juegoJson in json)
                                {
                                    string imagenPequeña = string.Empty;

                                    if (juegoJson.imagenPequeña != string.Empty)
                                    {
                                        imagenPequeña = juegoJson.imagenPequeña;
                                    }
                                    else
                                    {
                                        if (juegoJson.idSteam != string.Empty)
                                        {
                                            imagenPequeña = Steam.dominioImagenes + "/steam/apps/" + juegoJson.idSteam + "/header.jpg";
                                        }
                                    }

                                    string imagenGrande = string.Empty;

                                    if (juegoJson.imagenGrande != string.Empty)
                                    {
                                        imagenGrande = juegoJson.imagenGrande;
                                    }
                                    else
                                    {
                                        if (juegoJson.idSteam != string.Empty)
                                        {
                                            imagenGrande = Steam.dominioImagenes + "/steam/apps/" + juegoJson.idSteam + "/library_600x900.jpg";
                                        }
                                    }

                                    listaJuegos.Add(new BattlenetJuego(juegoJson.nombre, 
                                                        Strings.ChrW(34).ToString() + rutaEjecutable + Strings.ChrW(34).ToString() + " --exec=" + Strings.ChrW(34).ToString() + "launch " + juegoJson.idBattlenet + Strings.Chr(34).ToString(),
                                                        imagenPequeña, imagenGrande));
                                }
                            }
                        }
                    }

                    if (listaJuegos.Count > 0)
                    {
                        ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

                        if (datos.Values["BattlenetMensajeSiJuegos"] == null)
                        {
                            ObjetosVentana.gridBattlenetMensajeSiJuegos.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if ((bool)datos.Values["BattlenetMensajeSiJuegos"] == true)
                            {
                                ObjetosVentana.gridBattlenetMensajeSiJuegos.Visibility = Visibility.Visible;
                            }
                            else if ((bool)datos.Values["BattlenetMensajeSiJuegos"] == false)
                            {
                                ObjetosVentana.gridBattlenetMensajeSiJuegos.Visibility = Visibility.Collapsed;
                            }
                        }
                            
                        ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Collapsed;
                        ObjetosVentana.gvBattlenetJuegosInstalados.Visibility = Visibility.Visible;
                        ObjetosVentana.gvBattlenetJuegosInstalados.Items.Clear();

                        listaJuegos.Sort(delegate (BattlenetJuego c1, BattlenetJuego c2) { return c1.nombre.CompareTo(c2.nombre); });

                        foreach (BattlenetJuego juego in listaJuegos)
                        {
                            ImageEx imagen = new ImageEx
                            {
                                IsCacheEnabled = true,
                                EnableLazyLoading = true,
                                Stretch = Stretch.UniformToFill,
                                Source = juego.imagenGrande,
                                CornerRadius = new CornerRadius(2)
                            };

                            Button2 botonJuego = new Button2
                            {
                                Content = imagen,
                                Margin = new Thickness(0),
                                Padding = new Thickness(0),
                                BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                BorderThickness = new Thickness(3),
                                Tag = juego,
                                MaxWidth = 300,
                                CornerRadius = new CornerRadius(5)
                            };

                            botonJuego.Click += ImagenJuegoClick;
                            botonJuego.PointerEntered += Animaciones.EntraRatonBoton2;
                            botonJuego.PointerExited += Animaciones.SaleRatonBoton2;

                            GridViewItem item = new GridViewItem
                            {
                                Content = botonJuego,
                                Margin = new Thickness(5, 0, 5, 10)
                            };

                            ObjetosVentana.gvBattlenetJuegosInstalados.Items.Add(item);
                        }
                    }
                    else
                    {
                        ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ObjetosVentana.tbBattlenetMensajeNoJuegos.Visibility = Visibility.Visible;
            }

            ObjetosVentana.prBattlenetJuegosInstalados.Visibility = Visibility.Collapsed;
        }

        private static void ImagenJuegoClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            BattlenetJuego juego = boton.Tag as BattlenetJuego;

            WidgetPrecarga.PrecargarJuego(juego.nombre,
                    juego.ejecutable, null,
                    juego.imagenPequeña, juego.imagenGrande);
        }

        private static void CerrarMensajeSiJuegosClick(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.gridBattlenetMensajeSiJuegos.Visibility = Visibility.Collapsed;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["BattlenetMensajeSiJuegos"] = false;
        }
    }

    public class BattlenetJuego
    {
        public string nombre { get; set; }
        public string ejecutable { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenGrande { get; set; }

        public BattlenetJuego(string Nombre, string Ejecutable, string ImagenPequeña, string ImagenGrande)
        {
            nombre = Nombre;
            ejecutable = Ejecutable;
            imagenPequeña = ImagenPequeña;
            imagenGrande = ImagenGrande;
        }
    }
}
