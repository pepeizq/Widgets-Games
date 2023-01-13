using Microsoft.UI.Xaml.Controls;
using static Widgets_Games.MainWindow;

namespace Interfaz
{
    public class WidgetPrecarga
    {
        public void Cargar()
        {
            ObjetosVentana.tbWidgetPrecargaPequeña.TextChanged += EnlaceImagenPequeñaTextoCambia;
            ObjetosVentana.tbWidgetPrecargaGrande.TextChanged += EnlaceImagenGrandeTextoCambia;
        }

        private void EnlaceImagenPequeñaTextoCambia(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObjetosVentana.imagenWidgetPrecargaPequeña.Source = ObjetosVentana.tbWidgetPrecargaPequeña.Text;
            }
            catch 
            { }            
        }

        private void EnlaceImagenGrandeTextoCambia(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObjetosVentana.imagenWidgetPrecargaGrande.Source = ObjetosVentana.tbWidgetPrecargaGrande.Text;
            }
            catch
            { }
        }

        public static void CargarJuego(string nombre, string imagenPequeña, string imagenMedianaGrande)
        {
            Pestañas.Visibilidad(ObjetosVentana.gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            ObjetosVentana.tbWidgetPrecargaTitulo.Text = nombre;
            ObjetosVentana.tbWidgetPrecargaPequeña.Text = imagenPequeña;
            ObjetosVentana.tbWidgetPrecargaGrande.Text = imagenMedianaGrande;
        }
    }
}
