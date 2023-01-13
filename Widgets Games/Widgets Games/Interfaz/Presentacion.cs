using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace Interfaz
{
    public static class Presentacion
    {
        public static Button CreadorItems(string imagenEnlace, string nombre)
        {
            Button boton = new Button
            {
                Height = 80,
                Width = 220,
                Padding = new Thickness(20),
                Background = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"])
            };

            ImageEx imagen = new ImageEx
            {
                Source = imagenEnlace,
                IsCacheEnabled = true,
                EnableLazyLoading = true
            };

            boton.Content = imagen;

            return boton;
        }
    }
}
