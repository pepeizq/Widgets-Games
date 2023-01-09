using Herramientas;
using Microsoft.UI.Xaml;
using Microsoft.VisualBasic;
using Microsoft.Windows.Widgets.Providers;
using Plantillas;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Windows.Storage;
using Windows.System;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

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
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
         

            string plantilla = Ficheros.LeerFicheroDentroAplicacion("ms-appx:///Plantillas/Juego.json");

            Juego json = JsonSerializer.Deserialize<Juego>(plantilla);
            json.enlace = "steam://rungameid/1659420/";
            json.fondo.url = "https://cdn.cloudflare.steamstatic.com/steam/apps/1659420/library_600x900.jpg";

            Ficheros.EscribirFichero("Juego.json", JsonSerializer.Serialize(json));

            //await Launcher.LaunchFolderPathAsync(ApplicationData.Current.LocalFolder.Path);

            myButton.Content = "Clicked";

            //string plantilla = Herramientas.Ficheros.LeerFichero("ms-appx:///Plantillas/Test.json");

            //int int1 = plantilla.IndexOf(Strings.ChrW(34) + "url" + Strings.ChrW(34));
            //string temp1 = plantilla.Remove(0, int1 + 8);
            //int int2 = temp1.IndexOf(Strings.ChrW(34));

            //plantilla = plantilla.Remove(int1 + 8, int2);
            //plantilla = plantilla.Insert(int1 + 8, "https://www.elotrolado.net/foro_pc-online_64");

            //tbTest.Text = plantilla;

            //Herramientas.Ficheros.EscribirFichero("ms-appx:///Plantillas/Test.json", plantilla);

            //WidgetProveedor test = new WidgetProveedor();
            //test.Test();
        }
    }
}
