using Herramientas;
using Microsoft.Windows.Widgets.Providers;
using Plantillas;
using System;
using System.Diagnostics;
using System.Text.Json;
using Windows.Storage;
using Windows.System;

internal class WidgetJuego : WidgetBase
{
    public override async void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        string verb = actionInvokedArgs.Verb;

        if (verb == "AbrirJuego")
        {
            string plantilla = Ficheros.LeerFicheroFueraAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + ID + ".json");
            Juego json = JsonSerializer.Deserialize<Juego>(plantilla);

            if (json.enlace.Contains("steam://rungameid/") == true)
            {
                await Launcher.LaunchUriAsync(new Uri(json.enlace));
            }
            else
            {
                Process.Start(json.enlace);
            }           
        }
    }

    public override string CogerPlantilla(string id)
    {
        if (Ficheros.ExisteFichero(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + ID + ".json") == true)
        {
            return Ficheros.LeerFicheroDentroAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + ID + ".json");
        }
        else
        {
            string plantilla = Ficheros.LeerFicheroFueraAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego.json");
            Ficheros.EscribirFichero("Juego" + id + ".json", plantilla);
            return plantilla;
        }
    }
}