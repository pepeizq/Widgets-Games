using Microsoft.UI.Xaml.Controls;
using static Widgets_Games.MainWindow;

namespace Plataformas
{
    public static class Steam
    {
        public static void Cargar()
        {
            ObjetosVentana.tbSteamEnlaceJuego.TextChanged += EnlaceSteamTextoCambia;
        }

        private void EnlaceSteamTextoCambia(object sender, TextChangedEventArgs e)
        {
            TextBox tb = ObjetosVentana.tbSteamEnlaceJuego;

            if (tb.Text.Trim().Length > 0)
            {
                if (tb.Text.Contains("https://store.steampowered.com/app/") == true)
                {
                    ObjetosVentana.botonSteamGenerarPlantilla.IsEnabled = true;
                }
                else
                {
                    ObjetosVentana.botonSteamGenerarPlantilla.IsEnabled = false;
                }
            }
            else
            {
                ObjetosVentana.botonSteamGenerarPlantilla.IsEnabled = false;
            }
        }
    }
}
