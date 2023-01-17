using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plataformas;

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
            ScrollViewers.Cargar();
            Interfaz.Menu.Cargar();
            Trial.Cargar();
            Steam.Cargar();
            EAPlay.Cargar();
            WidgetPrecarga.Cargar();
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
            ObjetosVentana.menuItemMenu = menuItemMenu;
            ObjetosVentana.nvItemOpciones = nvItemOpciones;
            ObjetosVentana.nvItemSubirArriba = nvItemSubirArriba;

            //-------------------------------------------------------------------

            ObjetosVentana.gridPresentacion = gridPresentacion;
            ObjetosVentana.gridSteam = gridSteam;
            ObjetosVentana.gridGOG = gridGOG;
            ObjetosVentana.gridEAPlay = gridEAPlay;
            ObjetosVentana.gridWidgetPrecarga = gridWidgetPrecarga;
            ObjetosVentana.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            ObjetosVentana.svPresentacion = svPresentacion;
            ObjetosVentana.gvPresentacionPlataformas = gvPresentacionPlataformas;
            ObjetosVentana.spPresentacionTrial = spPresentacionTrial;
            ObjetosVentana.botonPresentacionTrialComprar = botonPresentacionTrialComprar;

            //-------------------------------------------------------------------

            ObjetosVentana.botonSteamJuegosInstalados = botonSteamJuegosInstalados;
            ObjetosVentana.botonSteamCualquierJuego = botonSteamCualquierJuego;
            ObjetosVentana.gridSteamJuegosInstalados = gridSteamJuegosInstalados;
            ObjetosVentana.svSteamJuegosInstalados = svSteamJuegosInstalados;
            ObjetosVentana.prSteamJuegosInstalados = prSteamJuegosInstalados;
            ObjetosVentana.gvSteamJuegosInstalados = gvSteamJuegosInstalados;
            ObjetosVentana.gridSteamCualquierJuego = gridSteamCualquierJuego;
            ObjetosVentana.tbSteamCualquierJuego = tbSteamEnlaceJuego;

            //-------------------------------------------------------------------

            ObjetosVentana.svGOGJuegosInstalados = svGOGJuegosInstalados;
            ObjetosVentana.prGOGJuegosInstalados = prGOGJuegosInstalados;
            ObjetosVentana.gvGOGJuegosInstalados = gvGOGJuegosInstalados;
            ObjetosVentana.tbGOGMensajeNoJuegos = tbGOGMensajeNoJuegos;

            //-------------------------------------------------------------------

            ObjetosVentana.botonEAPlayBuscarJuegosInstalados = botonEAPlayBuscarJuegosInstalados;
            ObjetosVentana.tbEAPlayCarpetaJuegosInstalados = tbEAPlayCarpetaJuegosInstalados;
            ObjetosVentana.svEAPlayJuegosInstalados = svEAPlayJuegosInstalados;
            ObjetosVentana.prEAPlayJuegosInstalados = prEAPlayJuegosInstalados;
            ObjetosVentana.gvEAPlayJuegosInstalados = gvEAPlayJuegosInstalados;
            ObjetosVentana.tbEAPlayMensajeNoJuegos = tbEAPlayMensajeNoJuegos;

            //-------------------------------------------------------------------

            ObjetosVentana.svWidgetPrecarga = svWidgetPrecarga;
            ObjetosVentana.tbWidgetPrecargaTitulo = tbWidgetPrecargaTitulo;
            ObjetosVentana.expanderWidgetPrecargaDatos = expanderWidgetPrecargaDatos;
            ObjetosVentana.tbWidgetPrecargaEjecutable = tbWidgetPrecargaEjecutable;
            ObjetosVentana.tbWidgetPrecargaArgumentos = tbWidgetPrecargaArgumentos;
            ObjetosVentana.tbWidgetPrecargaImagenPequeña = tbWidgetPrecargaPequena;
            ObjetosVentana.tbWidgetPrecargaImagenGrande = tbWidgetPrecargaGrande;
            ObjetosVentana.expanderWidgetPrecargaPersonalizacion = expanderWidgetPrecargaPersonalizacion;
            ObjetosVentana.cbWidgetPrecargaImagen = cbWidgetPrecargaImagen;
            ObjetosVentana.tbWidgetPrecargaMensajeImagen = tbWidgetPrecargaMensajeImagen;
            ObjetosVentana.imagenWidgetPrecargaElegida = imagenWidgetPrecargaElegida;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionHorizontal = cbWidgetPrecargaImagenOrientacionHorizontal;
            ObjetosVentana.cbWidgetPrecargaImagenOrientacionVertical = cbWidgetPrecargaImagenOrientacionVertical;
            ObjetosVentana.botonWidgetPrecargaCargarJuego = botonWidgetPrecargaCargarJuego;
            ObjetosVentana.tbWidgetCargarJuegoMensaje = tbWidgetCargarJuegoMensaje;

            //-------------------------------------------------------------------

            ObjetosVentana.svOpciones = svOpciones;
            ObjetosVentana.cbOpcionesIdioma = cbOpcionesIdioma;
            ObjetosVentana.cbOpcionesPantalla = cbOpcionesPantalla;
            ObjetosVentana.botonOpcionesLimpiar = botonOpcionesLimpiar;
        }

        public static class ObjetosVentana
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }
            public static NavigationViewItem nvItemMenu { get; set; }
            public static MenuFlyout menuItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }
            public static NavigationViewItem nvItemSubirArriba { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridPresentacion { get; set; }
            public static Grid gridSteam { get; set; }
            public static Grid gridGOG { get; set; }
            public static Grid gridEAPlay { get; set; }
            public static Grid gridWidgetPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svPresentacion { get; set; }
            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }
            public static StackPanel spPresentacionTrial { get; set; }
            public static Button botonPresentacionTrialComprar { get; set; }

            //-------------------------------------------------------------------

            public static Button botonSteamJuegosInstalados { get; set; }
            public static Button botonSteamCualquierJuego { get; set; }
            public static Grid gridSteamJuegosInstalados { get; set; }
            public static ScrollViewer svSteamJuegosInstalados { get; set; }
            public static ProgressRing prSteamJuegosInstalados { get; set; }
            public static AdaptiveGridView gvSteamJuegosInstalados { get; set; }
            public static Grid gridSteamCualquierJuego { get; set; }
            public static TextBox tbSteamCualquierJuego { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svGOGJuegosInstalados { get; set; }
            public static ProgressRing prGOGJuegosInstalados { get; set; }
            public static AdaptiveGridView gvGOGJuegosInstalados { get; set; }
            public static TextBlock tbGOGMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static Button botonEAPlayBuscarJuegosInstalados { get; set; }
            public static TextBlock tbEAPlayCarpetaJuegosInstalados { get; set; }
            public static ScrollViewer svEAPlayJuegosInstalados { get; set; }
            public static ProgressRing prEAPlayJuegosInstalados { get; set; }
            public static AdaptiveGridView gvEAPlayJuegosInstalados { get; set; }
            public static TextBlock tbEAPlayMensajeNoJuegos { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svWidgetPrecarga { get; set; }
            public static TextBlock tbWidgetPrecargaTitulo { get; set; }
            public static Microsoft.UI.Xaml.Controls.Expander expanderWidgetPrecargaDatos { get; set; }
            public static TextBox tbWidgetPrecargaEjecutable { get; set; }
            public static TextBox tbWidgetPrecargaArgumentos { get; set; }
            public static TextBox tbWidgetPrecargaImagenPequeña { get; set; }
            public static TextBox tbWidgetPrecargaImagenGrande { get; set; }
            public static Microsoft.UI.Xaml.Controls.Expander expanderWidgetPrecargaPersonalizacion { get; set; }
            public static ComboBox cbWidgetPrecargaImagen { get; set; }
            public static TextBlock tbWidgetPrecargaMensajeImagen { get; set; }
            public static ImageEx imagenWidgetPrecargaElegida { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionHorizontal { get; set; }
            public static ComboBox cbWidgetPrecargaImagenOrientacionVertical { get; set; }
            public static Button botonWidgetPrecargaCargarJuego { get; set; }
            public static TextBlock tbWidgetCargarJuegoMensaje { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svOpciones { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.CreadorItems("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyGame"));
            Pestañas.CreadorItems("/Assets/Plataformas/logo_ubisoft.png", "Ubisoft Connect");
            Pestañas.CreadorItems("/Assets/Plataformas/logo_eaplay.png", "EA Play");
            Pestañas.CreadorItems("/Assets/Plataformas/logo_gog.png", "GOG");           
            Pestañas.CreadorItems("/Assets/Plataformas/logo_steam.png", "Steam");
            

            Button botonSteam = Presentacion.CreadorBotones("/Assets/Plataformas/logo_steam_completo.png", "Steam", false);
            botonSteam.Click += AbrirSteamClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonSteam);

            Button botonGOG = Presentacion.CreadorBotones("/Assets/Plataformas/logo_gog.png", "GOG", false);
            botonGOG.Click += AbrirGOGClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonGOG);

            Button botonEAPlay = Presentacion.CreadorBotones("/Assets/Plataformas/logo_eaplay_completo.png", "EA Play", false);
            botonEAPlay.Click += AbrirEAPlayClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonEAPlay);

            Button botonUbisoft = Presentacion.CreadorBotones("/Assets/Plataformas/logo_ubisoft_completo.png", "Ubisoft Connect", false);
            botonUbisoft.Click += AbrirEAPlayClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonUbisoft);

            Button botonCualquierJuego = Presentacion.CreadorBotones("/Assets/Plataformas/logo_cualquierjuego.png", recursos.GetString("AnyGame"), true);
            botonCualquierJuego.Click += AbrirCualquierJuegoClick;
            ObjetosVentana.gvPresentacionPlataformas.Items.Add(botonCualquierJuego);
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
                        Pestañas.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        ScrollViewers.EnseñarSubir(svOpciones);
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
                                ScrollViewers.EnseñarSubir(svSteamJuegosInstalados);
                                Steam.CargarJuegosInstalados();
                            }
                            else if (tb.Text == "GOG")
                            {
                                Pestañas.Visibilidad(gridGOG, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svGOGJuegosInstalados);
                                GOG.Cargar();
                            }
                            else if (tb.Text == "EA Play")
                            {
                                Pestañas.Visibilidad(gridEAPlay, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svEAPlayJuegosInstalados);
                                EAPlay.CargarJuegosInstalados();
                            }
                            else if (tb.Text == recursos.GetString("AnyGame"))
                            {
                                Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
                                BarraTitulo.CambiarTitulo(null);
                                WidgetPrecarga.PrecargarJuego(null, null, null, null, null);
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
            ScrollViewers.EnseñarSubir(svSteamJuegosInstalados);
            Steam.CargarJuegosInstalados();
        }

        private void AbrirGOGClick(object sender, RoutedEventArgs e) 
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[2];
            Pestañas.Visibilidad(gridGOG, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svGOGJuegosInstalados);
            GOG.Cargar();
        }

        private void AbrirEAPlayClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[3];
            Pestañas.Visibilidad(gridEAPlay, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.EnseñarSubir(svEAPlayJuegosInstalados);
            EAPlay.CargarJuegosInstalados();
        }

        private void AbrirCualquierJuegoClick(object sender, RoutedEventArgs e)
        {
            Pestañas.Visibilidad(gridWidgetPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            WidgetPrecarga.PrecargarJuego(null, null, null, null, null);
        }
    }
}
