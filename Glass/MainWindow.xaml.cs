using Glass.Data;
using System;
using System.Windows;

namespace Glass
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const String UrlFox = "http://sheemin.club/api/v1";

        public ContextoServicio Contexto { get; }
        public Sesion Sesion { get; }

        public MainWindow()
        {
            Contexto = new ContextoServicio(UrlFox);
            Sesion = new Sesion();

            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;

            NavFrame.Navigate(new InicioSesion(this));
        }
    }
}
