using Glass.Data;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace Glass
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const String UrlFox = "http://sheemin.club/api/v1";

        public readonly Boolean IsMock = true;
        public readonly Int32 RolMock = 2;

        public ContextoServicio Contexto { get; }
        public Sesion Sesion { get; }

        public MainWindow()
        {
            Contexto = new ContextoServicio(UrlFox);
            Sesion = new Sesion();

            InitializeComponent();
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.NoResize;

            NavFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            NavFrame.Navigate(new InicioSesion(this));
        }
    }
}
