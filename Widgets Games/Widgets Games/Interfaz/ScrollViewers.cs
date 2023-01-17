using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public static class ScrollViewers
    {
        public static void Cargar()
        {
            ObjetosVentana.nvItemSubirArriba.PointerPressed += SubirArriba;
            ObjetosVentana.nvItemSubirArriba.PointerEntered += Animaciones.EntraRatonNvItem;
            ObjetosVentana.nvItemSubirArriba.PointerExited += Animaciones.SaleRatonNvItem;

            ObjetosVentana.svPresentacion.ViewChanging += svScroll;
            ObjetosVentana.svSteamJuegosInstalados.ViewChanging += svScroll;
            ObjetosVentana.svGOGJuegosInstalados.ViewChanging += svScroll;
            ObjetosVentana.svEAPlayJuegosInstalados.ViewChanging += svScroll;
            ObjetosVentana.svWidgetPrecarga.ViewChanging += svScroll;
            ObjetosVentana.svOpciones.ViewChanging += svScroll;
        }

        private static void svScroll(object sender, ScrollViewerViewChangingEventArgs args)
        {
            ScrollViewer sv = sender as ScrollViewer;

            if (sv.VerticalOffset > 150)
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }

        public static void SubirArriba(object sender, RoutedEventArgs e)
        {
            NavigationViewItem nvItem = sender as NavigationViewItem;
            nvItem.Visibility = Visibility.Collapsed;

            Grid grid = nvItem.Content as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);

            if (ObjetosVentana.gridSteam.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svSteamJuegosInstalados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridGOG.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svGOGJuegosInstalados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridEAPlay.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svEAPlayJuegosInstalados.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridWidgetPrecarga.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svWidgetPrecarga.ChangeView(null, 0, null);
            }
            else if (ObjetosVentana.gridOpciones.Visibility == Visibility.Visible)
            {
                ObjetosVentana.svOpciones.ChangeView(null, 0, null);
            }
        }

        public static void EnseñarSubir(ScrollViewer sv)
        {
            if (sv.VerticalOffset > 50)
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                ObjetosVentana.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }
    }
}
