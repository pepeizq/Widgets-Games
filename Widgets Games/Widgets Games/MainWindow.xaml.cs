using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using Plataformas;
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
            Pestañas.Cargar();

            Presentacion.Cargar();

            Steam steam = new Steam();
            steam.Cargar();

            Opciones.CargarDatos();

            ObjetosVentana.botonSteamGenerarPlantilla.Click += GenerarPlantillaClick;
        }

        public void CargarObjetosVentana()
        {
            ObjetosVentana.ventana = ventana;
            ObjetosVentana.gridTitulo = gridTitulo;
            ObjetosVentana.tbTitulo = tbTitulo;
            ObjetosVentana.nvPrincipal = nvPrincipal;
            ObjetosVentana.nvItemMenu = nvItemMenu;
            ObjetosVentana.nvItemOpciones = nvItemOpciones;

            ObjetosVentana.gridPresentacion = gridPresentacion;
            ObjetosVentana.gridSteam = gridSteam;
            ObjetosVentana.gridCargarWidget = gridCargarWidget;
            ObjetosVentana.gridOpciones = gridOpciones;

            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;

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
            public static NavigationViewItem nvItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }

            public static Grid gridPresentacion { get; set; }
            public static Grid gridSteam { get; set; }
            public static Grid gridCargarWidget { get; set; }
            public static Grid gridOpciones { get; set; }


            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }


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
            Pestañas.CreadorItems("/Assets/Plataformas/logo_steam.png", "Steam", null);

            Presentacion.CreadorItems("/Assets/Plataformas/logo_steam_completo.png", "Steam");
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (args.InvokedItemContainer != null)
            {
                if (args.InvokedItemContainer.GetType() == typeof(NavigationViewItem))
                {
                    NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;

                    if (item.Name == "nvItemMenu")
                    {

                    }
                    else if (item.Name == "nvItemOpciones")
                    {
                        //Opciones.CargarPestaña();
                        Pestañas.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        //ScrollViewers.EnseñarSubir(svOpciones);
                    }
                }
            }

            if (args.InvokedItem != null)
            {
                if (args.InvokedItem.GetType() == typeof(StackPanel))
                {
                    StackPanel sp = (StackPanel)args.InvokedItem;

                    if (sp.Children[1] != null)
                    {
                        if (sp.Children[1].GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = sp.Children[1] as TextBlock;

                            if (tb.Text == "Steam")
                            {
                                Pestañas.Visibilidad(gridSteam, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                //ScrollViewers.EnseñarSubir(svEntradas);
                            }

                        }
                    }
                }
            }
        }
     }
}
