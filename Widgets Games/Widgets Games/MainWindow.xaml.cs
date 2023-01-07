using Microsoft.UI.Xaml;
using Microsoft.VisualBasic;
using Microsoft.Windows.Widgets.Providers;
using System;
using System.Text.Json.Nodes;
using Windows.Storage;
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

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            //string plantilla = Herramientas.Ficheros.LeerFichero("ms-appx:///Plantillas/Test.json");

            //int int1 = plantilla.IndexOf(Strings.ChrW(34) + "url" + Strings.ChrW(34));
            //string temp1 = plantilla.Remove(0, int1 + 8);
            //int int2 = temp1.IndexOf(Strings.ChrW(34));

            //plantilla = plantilla.Remove(int1 + 8, int2);
            //plantilla = plantilla.Insert(int1 + 8, "https://www.elotrolado.net/foro_pc-online_64");

            //tbTest.Text = plantilla;

            //Herramientas.Ficheros.EscribirFichero("ms-appx:///Plantillas/Test.json", plantilla);

            WidgetProveedor test = new WidgetProveedor();
            test.Test();
        }
    }
}
