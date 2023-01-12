using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public static class Presentacion
    {
        public static void Cargar()
        {

        }

        public static void CreadorItems(string imagenEnlace, string nombre)
        {
            Button boton = new Button();

            ImageEx imagen = new ImageEx();

            ObjetosVentana.gvPresentacionPlataformas.Items.Add(boton);
        }
    }
}
