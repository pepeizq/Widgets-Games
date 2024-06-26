﻿using Herramientas;
using Interfaz;
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

            if (WidgetPrecarga.ComprobarURI(json.enlace) == true)
            {
                await Launcher.LaunchUriAsync(new Uri(json.enlace));
            }
            else
            {
                string ejecutable = json.enlace.Trim();
                string argumentos = json.argumentos.Trim();
               
                Process proceso = new Process();
                proceso.StartInfo.FileName = ejecutable;
                
                if (argumentos.Length > 0)
                {
                    proceso.StartInfo.Arguments = argumentos;
                    proceso.StartInfo.RedirectStandardInput = true;
                    proceso.StartInfo.UseShellExecute = false;
                    proceso.StartInfo.CreateNoWindow = true;
                }
                
                proceso.Start();
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