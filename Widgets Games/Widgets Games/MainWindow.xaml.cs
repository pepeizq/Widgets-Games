using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plantillas;
using Plataformas;
using System.Text.Json;

//https://nicksnettravels.builttoroam.com/windows-widget/
//https://www.adaptivecards.io/designer/
//https://learn.microsoft.com/es-es/windows/apps/develop/widgets/widget-providers
//https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.windows.widgets.providers.widgetmanager.updatewidget?view=windows-app-sdk-1.2

namespace Widgets_Games
{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CargarObjetosVentana();

            BarraTitulo.Generar(this);
            BarraTitulo.CambiarTitulo(null);
            Pestañas.Cargar();

            Steam steam = new Steam();
            steam.Cargar();

            WidgetPrecarga precarga = new WidgetPrecarga();
            precarga.Cargar();

            Opciones.CargarDatos();

            Pestañas.Visibilidad(gridPresentacion, true, null, false);
        }

        public void CargarObjetosVentana()
        {
            ObjetosVentana.ventana = ventana;
            ObjetosVentana.gridTitulo = gridTitulo;
            ObjetosVentana.tbTitulo = tbTitulo;
            ObjetosVentana.nvPrincipal = nvPrincipal;
            ObjetosVentana.nvItemMenu = nvItemMenu;
            ObjetosVentana.nvItemOpciones = nvItemOpciones;

            ObjetosVentana.gridPresentacion = gridPresentacion;
            ObjetosVentana.gridSteam = gridSteam;
            ObjetosVentana.gridWidgetPrecarga = gridWidgetPrecarga;
            ObjetosVentana.gridOpciones = gridOpciones;

            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;

            ObjetosVentana.botonSteamJuegosInstalados = botonSteamJuegosInstalados;
            ObjetosVentana.botonSteamCualquierJuego = botonSteamCualquierJuego;
            ObjetosVentana.gridSteamJuegosInstalados = gridSteamJuegosInstalados;
            ObjetosVentana.gridSteamCualquierJuego = gridSteamCualquierJuego;
            ObjetosVentana.tbSteamEnlaceJuego = tbSteamEnlaceJuego;

            ObjetosVentana.tbWidgetPrecargaTitulo = tbWidgetPrecargaTitulo;
            ObjetosVentana.imagenWidgetPrecargaPequeña = imagenWidgetPrecargaPequena;
            ObjetosVentana.tbWidgetPrecargaPequeña = tbWidgetPrecargaPequena;
            ObjetosVentana.imagenWidgetPrecargaGrande = imagenWidgetPrecargaGrande;
            ObjetosVentana.tbWidgetPrecargaGrande = tbWidgetPrecargaGrande;

            ObjetosVentana.botonSteamGenerarPlantilla = botonSteamGenerarPlantilla;
            ObjetosVentana.tbMensaje = tbMensaje;
        }

        public static class ObjetosVentana
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }
            public static NavigationViewItem nvItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }


            public static Grid gridPresentacion { get; set; }
            public static Grid gridSteam { get; set; }
            public static Grid gridWidgetPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }


            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }


            public static Button botonSteamJuegosInstalados { get; set; }
            public static Button botonSteamCualquierJuego { get; set; }
            public static Grid gridSteamJuegosInstalados { get; set; }
            public static Grid gridSteamCualquierJuego { get; set; }
            public static TextBox tbSteamEnlaceJuego { get; set; }


            public static TextBlock tbWidgetPrecargaTitulo { get; set; }
            public static ImageEx imagenWidgetPrecargaPequeña { get; set; }
            public static TextBox tbWidgetPrecargaPequeña { get; set; }
            public static ImageEx imagenWidgetPrecargaGrande { get; set; }
            public static TextBox tbWidgetPrecargaGrande { get; set; }





            public static Button botonSteamGenerarPlantilla { get; set; }
            public static TextBlock tbMensaje { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            Pestañas.CreadorItems("/Assets/Plataformas/logo_steam.png", "Steam", null);

            Button botonSteam = Presentacion.CreadorItems("/Assets/Plataformas/logo_steam_completo.png", "Steam");
            botonSteam.Click += AbrirSteamClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonSteam);
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (args.InvokedItemContainer != null)
            {
                if (args.InvokedItemContainer.GetType() == typeof(NavigationViewItem))
                {
                    NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;

                    if (item.Name == "nvItemMenu")
                    {

                    }
                    else if (item.Name == "nvItemOpciones")
                    {
                        //Opciones.CargarPestaña();
                        Pestañas.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        //ScrollViewers.EnseñarSubir(svOpciones);
                    }
                }
            }

            if (args.InvokedItem != null)
            {
                if (args.InvokedItem.GetType() == typeof(StackPanel))
                {
                    StackPanel sp = (StackPanel)args.InvokedItem;

                    if (sp.Children[1] != null)
                    {
                        if (sp.Children[1].GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = sp.Children[1] as TextBlock;

                            if (tb.Text == "Steam")
                            {
                                Pestañas.Visibilidad(gridSteam, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                //ScrollViewers.EnseñarSubir(svEntradas);
                            }

                        }
                    }
                }
            }
        }

        private void AbrirSteamClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[1];
            Pestañas.Visibilidad(gridSteam, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            //ScrollViewers.EnseñarSubir(svEntradas);
        }
    }
}
