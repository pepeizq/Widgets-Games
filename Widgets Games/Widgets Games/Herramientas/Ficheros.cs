using System;
using Windows.Storage;

namespace Herramientas
{
    public static class Ficheros
    {
        public static bool ExisteFichero(string enlaceFichero)
        {
            Uri enlace = new Uri(enlaceFichero);

            try
            {
                StorageFile fichero = StorageFile.GetFileFromApplicationUriAsync(enlace).AsTask().Result;

                if (fichero != null) 
                {
                    return true;
                }
            }
            catch
            {

            }

            return false;
        }

        public static string LeerFichero(string enlaceFichero)
        {
            Uri enlace = new Uri(enlaceFichero);
            StorageFile fichero = StorageFile.GetFileFromApplicationUriAsync(enlace).AsTask().Result;
            return FileIO.ReadTextAsync(fichero).AsTask().Result;
        }

        public static void EscribirFichero(string nombreFichero, string contenido)
        {
            StorageFolder carpetaApp = ApplicationData.Current.LocalFolder;

            if (carpetaApp.GetFolderAsync("Plantillas").AsTask().Result == null)
            {
                carpetaApp.CreateFolderAsync("Plantillas", CreationCollisionOption.FailIfExists).AsTask();
            }

            StorageFolder carpetaPlantillas = carpetaApp.GetFolderAsync("Plantillas").AsTask().Result;
            StorageFile fichero = carpetaPlantillas.CreateFileAsync(nombreFichero, CreationCollisionOption.ReplaceExisting).AsTask().Result;

            FileIO.WriteTextAsync(fichero, contenido).AsTask();
        }
    }
}
