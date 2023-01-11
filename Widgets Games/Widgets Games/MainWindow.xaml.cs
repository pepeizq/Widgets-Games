using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Plantillas;
using System.Text.Json;

//https://nicksnettravels.builttoroam.com/windows-widget/
//https://www.adaptivecards.io/designer/
//https://learn.microsoft.com/es-es/windows/apps/develop/widgets/widget-providers
//https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.windows.widgets.providers.widgetmanager.updatewidget?view=windows-app-sdk-1.2

namespace Widgets_Games
{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CargarObjetosVentana();

            BarraTitulo.Generar(this);
            BarraTitulo.CambiarTitulo(null);

            
            ObjetosVentana.botonSteamGenerarPlantilla.Click += GenerarPlantillaClick;
        }

        public void CargarObjetosVentana()
        {
            ObjetosVentana.ventana = ventana;
            ObjetosVentana.gridTitulo = gridTitulo;
            ObjetosVentana.tbTitulo = tbTitulo;

            ObjetosVentana.gridPresentacion = gridPresentacion;
            ObjetosVentana.gridSteam = gridSteam;
            ObjetosVentana.gridCargarWidget = gridCargarWidget;

            ObjetosVentana.tbSteamEnlaceJuego = tbSteamEnlaceJuego;
            ObjetosVentana.botonSteamGenerarPlantilla = botonSteamGenerarPlantilla;
            ObjetosVentana.tbMensaje = tbMensaje;
        }

        public static class ObjetosVentana
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }

            public static Grid gridPresentacion { get; set; }
            public static Grid gridSteam { get; set; }
            public static Grid gridCargarWidget { get; set; }



            public static TextBox tbSteamEnlaceJuego { get; set; }
            public static Button botonSteamGenerarPlantilla { get; set; }
            public static TextBlock tbMensaje { get; set; }
        }



        private void GenerarPlantillaClick(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.tbSteamEnlaceJuego.IsEnabled = false;
            ObjetosVentana.botonSteamGenerarPlantilla.IsEnabled = false;

            TextBox tb = ObjetosVentana.tbSteamEnlaceJuego;

            if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
            {
                string id = tb.Text;
                id = id.Replace("https://store.steampowered.com/app/", null);

                if (id.Contains("/") == true)
                {
                    int int1 = id.IndexOf("/");
                    id = id.Remove(int1, id.Length - int1);
                }

                string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Juego.json");

                Juego json = JsonSerializer.Deserialize<Juego>(plantilla);
                json.enlace = "steam://rungameid/" + id + "/";
                json.fondo.url = "https://cdn.cloudflare.steamstatic.com/steam/apps/" + id + "/library_600x900.jpg";

                Ficheros.EscribirFichero("Juego.json", JsonSerializer.Serialize(json));

                tbMensaje.Text = "Preloaded widget, go to Widgets app and add game widget from 'Add widgets'";
            }

            ObjetosVentana.tbSteamEnlaceJuego.IsEnabled = true;
            ObjetosVentana.botonSteamGenerarPlantilla.IsEnabled = true;
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            //ResourceLoader recursos = new ResourceLoader();

            //Pesta�as.CreadorItems(recursos.GetString("Subscriptions"), null);
            //Pesta�as.CreadorItems(recursos.GetString("Free"), null);
            //Pesta�as.CreadorItems(recursos.GetString("Bundles"), null);
            //Pesta�as.CreadorItems(recursos.GetString("Deals"), null);
            //Pesta�as.CreadorItems(recursos.GetString("All"), null);
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
        }
        }
}
