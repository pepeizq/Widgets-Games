using Herramientas;
using Microsoft.Windows.Widgets.Providers;
using Plantillas;
using System;
using System.Text.Json;
using Windows.Storage;
using Windows.System;

internal class WidgetJuego : WidgetBase
{
    private const int NumeroEmpieza = 10000;
    private int contador = NumeroEmpieza;

    public override string Enlace
    {
        get => base.Enlace;
    }

    public override string Estado
    {
        get => base.Estado;

        set
        {
            base.Estado = value;

            if (string.IsNullOrWhiteSpace(value))
            {
                Estado = NumeroEmpieza.ToString();
            }
            else
            {
                try
                {
                    contador = int.Parse(value);
                }
                catch
                {
                    Estado = NumeroEmpieza.ToString();
                }
            }
        }
    }

    public override async void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        string verb = actionInvokedArgs.Verb;

        if (verb == "AbrirJuego")
        {
            //contador--;
            //Estado = contador + "";

            string datos = GetDataForWidget();
            Notificaciones.Toast(datos);

            //await Launcher.LaunchUriAsync(new Uri(datos));

            //WidgetUpdateRequestOptions actualizarOpciones = new WidgetUpdateRequestOptions(ID)
            //{
            //    Data = datos,
            //    CustomState = Estado
            //};

            //WidgetManager.GetDefault().UpdateWidget(actualizarOpciones);
        }
    }

    public override string GetTemplateForWidget(string id)
    {
        if (Ficheros.ExisteFichero(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + id + ".json") == true)
        {
            return Ficheros.LeerFicheroDentroAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + id + ".json");
        }
        else
        {
            string plantilla = Ficheros.LeerFicheroFueraAplicacion(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego.json");
            Ficheros.EscribirFichero("Juego" + id + ".json", plantilla);
            return plantilla;
        }
    }

    public override string GetDataForWidget()
    {
        return "{ \"enlace\": " + Enlace + " }";
    }
}