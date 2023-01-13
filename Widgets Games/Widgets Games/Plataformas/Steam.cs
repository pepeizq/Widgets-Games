using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Newtonsoft.Json;
using static Widgets_Games.MainWindow;

namespace Plataformas
{
    public class Steam
    {
        public void Cargar()
        {
            CambiarSubPestañaInstalados();

            //-------------------------------------

            ObjetosVentana.botonSteamJuegosInstalados.Click += CambiarSubPestañaInstalados;
            ObjetosVentana.botonSteamCualquierJuego.Click += CambiarSubPestañaCualquiera;

            ObjetosVentana.tbSteamEnlaceJuego.TextChanged += EnlaceSteamTextoCambia;
        }

        private void CambiarSubPestañaInstalados(object sender, RoutedEventArgs e)
        {
            CambiarSubPestañaInstalados();
        }

        private void CambiarSubPestañaInstalados()
        {
            ObjetosVentana.gridSteamJuegosInstalados.Visibility = Visibility.Visible;
            ObjetosVentana.gridSteamCualquierJuego.Visibility = Visibility.Collapsed;

            ObjetosVentana.botonSteamJuegosInstalados.BorderThickness = new Thickness(0, 0, 0, 1);
            ObjetosVentana.botonSteamCualquierJuego.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void CambiarSubPestañaCualquiera(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.gridSteamJuegosInstalados.Visibility = Visibility.Collapsed;
            ObjetosVentana.gridSteamCualquierJuego.Visibility = Visibility.Visible;

            ObjetosVentana.botonSteamJuegosInstalados.BorderThickness = new Thickness(0, 0, 0, 0);
            ObjetosVentana.botonSteamCualquierJuego.BorderThickness = new Thickness(0, 0, 0, 1);
        }

        private async void EnlaceSteamTextoCambia(object sender, TextChangedEventArgs e)
        {
            TextBox tb = ObjetosVentana.tbSteamEnlaceJuego;

            if (tb.Text.Trim().Length > 0)
            {
                if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
                {
                    ObjetosVentana.tbSteamEnlaceJuego.IsEnabled = false;

                    if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
                    {
                        string id = tb.Text;
                        id = id.Replace("https://store.steampowered.com/app/", null);

                        if (id.Contains("/") == true)
                        {
                            int int1 = id.IndexOf("/");
                            id = id.Remove(int1, id.Length - int1);
                        }

                        string html = await Decompiladores.CogerHtml("https://store.steampowered.com/api/appdetails?appids=" + id);

                        if (html != null)
                        {
                            int int1 = html.IndexOf(":");
                            string temp1 = html.Remove(0, int1 + 1);
                            temp1 = temp1.Remove(temp1.Length - 1, 1);

                            SteamAPI json = JsonConvert.DeserializeObject<SteamAPI>(temp1);

                            if (json != null)
                            {
                                WidgetPrecarga.CargarJuego(json.datos.titulo, "https://cdn.cloudflare.steamstatic.com/steam/apps/" + id + "/header.jpg", "https://cdn.cloudflare.steamstatic.com/steam/apps/" + id + "/library_600x900.jpg");
                            }
                        }
                        

                        //string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Juego.json");

                        //Juego json = JsonSerializer.Deserialize<Juego>(plantilla);
                        //json.enlace = "steam://rungameid/" + id + "/";
                        //json.fondo.url = "https://cdn.cloudflare.steamstatic.com/steam/apps/" + id + "/library_600x900.jpg";

                        //Ficheros.EscribirFichero("Juego.json", JsonSerializer.Serialize(json));

                        //tbMensaje.Text = "Preloaded widget, go to Widgets app and add game widget from 'Add widgets'";
                    }

                    ObjetosVentana.tbSteamEnlaceJuego.IsEnabled = true;
                }
            }
        }
    }
}
