using FontAwesome5;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using Windows.ApplicationModel;
using Windows.System;
using Windows.UI;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public static class Menu
    {
        public static void Cargar()
        {
            ResourceLoader recursos = new ResourceLoader();
           
            //--------------------------------------------------------------------

            FontAwesome icono1 = new FontAwesome
            {
                Icon = EFontAwesomeIcon.Solid_ThumbsUp,
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            };

            MenuFlyoutItem item1 = new MenuFlyoutItem
            {
                Icon = icono1,
                Text = recursos.GetString("MenuRate"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark
            };

            item1.Click += BotonAbrirVotar;

            ObjetosVentana.menuItemMenu.Items.Add(item1);

            FontAwesome icono2 = new FontAwesome
            {
                Icon = EFontAwesomeIcon.Brands_Github,
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            };

            MenuFlyoutItem item2 = new MenuFlyoutItem
            {
                Icon = icono2,
                Text = recursos.GetString("MenuGithub"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark
            };

            item2.Click += BotonAbrirCodigoFuente;

            ObjetosVentana.menuItemMenu.Items.Add(item2);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador1 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador1);

            //--------------------------------------------------------------------

            MenuFlyoutItem item3 = new MenuFlyoutItem
            {
                Text = recursos.GetString("MenuContact"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item3.Click += BotonAbrirContactar;

            ObjetosVentana.menuItemMenu.Items.Add(item3);

            MenuFlyoutItem item4 = new MenuFlyoutItem
            {
                Text = recursos.GetString("MenuPatchNotes"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item4.Click += BotonAbrirNotasParche;

            ObjetosVentana.menuItemMenu.Items.Add(item4);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador2 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador2);

            //--------------------------------------------------------------------

            MenuFlyoutItem item5 = new MenuFlyoutItem
            {
                Text = "pepeizqapps.com",
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item5.Click += BotonAbrirWeb1;

            ObjetosVentana.menuItemMenu.Items.Add(item5);

            MenuFlyoutItem item6 = new MenuFlyoutItem
            {
                Text = "pepeizqdeals.com",
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item6.Click += BotonAbrirWeb2;

            ObjetosVentana.menuItemMenu.Items.Add(item6);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador3 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador3);

            //--------------------------------------------------------------------

            MenuFlyoutItem item7 = new MenuFlyoutItem
            {
                Text = recursos.GetString("MenuExit"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item7.Click += BotonCerrarApp;

            ObjetosVentana.menuItemMenu.Items.Add(item7);
        }

        public async static void BotonAbrirVotar(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + Package.Current.Id.FamilyName));
        }

        public async static void BotonAbrirCodigoFuente(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://github.com/pepeizq/Widgets-Games"));
        }

        public async static void BotonAbrirContactar(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/contact/"));
        }

        public async static void BotonAbrirNotasParche(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/patch-notes/"));
        }

        public async static void BotonAbrirWeb1(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/"));
        }

        public async static void BotonAbrirWeb2(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqdeals.com/"));
        }

        public static void BotonCerrarApp(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Exit();
        }
    }
}
