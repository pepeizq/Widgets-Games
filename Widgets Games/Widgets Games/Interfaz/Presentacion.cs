using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace Interfaz
{
    public static class Presentacion
    {
        public static Button CreadorBotones(string imagenEnlace, string nombre, bool mostrarNombre)
        {
            Button boton = new Button
            {
                Height = 80,
                Width = 250,
                Padding = new Thickness(20),
                Background = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                Margin = new Thickness(10)
            };

            StackPanel sp = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            ImageEx imagen = new ImageEx
            {
                Source = imagenEnlace,
                IsCacheEnabled = true,
                EnableLazyLoading = true
            };

            sp.Children.Add(imagen);

            if (mostrarNombre == true)
            {
                TextBlock tb = new TextBlock
                {
                    Text = nombre,
                    Margin = new Thickness(20, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap
                };

                sp.Children.Add(tb);
            }

            boton.Content = sp;

            return boton;
        }
    }
}
