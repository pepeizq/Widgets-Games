using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace Interfaz
{
    public static class Animaciones
    {
        public static void EntraRatonGrid(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush fondo = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            {
                Opacity = 0.2
            };

            Grid grid = sender as Grid;
            grid.Background = fondo;
        }

        public static void SaleRatonGrid(object sender, PointerRoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);
        }

        public static void EntraRatonNvItem(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush fondo = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            {
                Opacity = 0.2
            };

            NavigationViewItem nvItem = sender as NavigationViewItem;
            Grid grid = nvItem.Content as Grid;
            grid.Background = fondo;

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(AnimatedIcon))
                {
                    AnimatedIcon icono = grid.Children[0] as AnimatedIcon;
                    AnimatedIcon.SetState(icono, "Pressed");
                }
            }
        }

        public static void SaleRatonNvItem(object sender, PointerRoutedEventArgs e)
        {
            NavigationViewItem nvItem = sender as NavigationViewItem;
            Grid grid = nvItem.Content as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(AnimatedIcon))
                {
                    AnimatedIcon icono = grid.Children[0] as AnimatedIcon;
                    AnimatedIcon.SetState(icono, "Normal");
                }
            }
        }

        public static void EntraRatonBoton(object sender, PointerRoutedEventArgs e)
        {
            Button boton = sender as Button;
            Grid grid = boton.Content as Grid;

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(TextBlock))
                {
                    TextBlock tb = grid.Children[0] as TextBlock;
                    tb.Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
                }
            }
        }

        public static void SaleRatonBoton(object sender, PointerRoutedEventArgs e)
        {
            Button boton = sender as Button;
            Grid grid = boton.Content as Grid;

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(TextBlock))
                {
                    TextBlock tb = grid.Children[0] as TextBlock;
                    tb.Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]);
                }
            }
        }
    }
}
