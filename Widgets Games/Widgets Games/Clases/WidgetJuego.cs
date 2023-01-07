using Herramientas;
using Microsoft.Windows.Widgets.Providers;
using System;
using Windows.Storage;

internal class WidgetJuego : WidgetBase
{
    private const int NumeroEmpieza = 10000;
    private int contador = NumeroEmpieza;

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

    public override void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        string verb = actionInvokedArgs.Verb;

        if (verb == "AbrirJuego")
        {
            //contador--;
            //Estado = contador + "";

            string datos = GetDataForWidget();
            Notificaciones.Toast(datos);
            Windows.System.Launcher.LaunchUriAsync(new Uri("steam://rungameid/268130")).AsTask();

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
            return Ficheros.LeerFichero(ApplicationData.Current.LocalFolder.Path + "/Plantillas/Juego" + id + ".json");
        }
        else
        {
            string plantilla = Ficheros.LeerFichero("ms-appx:///Plantillas/Juego.json");
            Ficheros.EscribirFichero("Juego" + id + ".json", plantilla);
            return plantilla;
        }
    }

    public override string GetDataForWidget()
    {
        return "{ \"state\": " + Estado + " }";
    }
}