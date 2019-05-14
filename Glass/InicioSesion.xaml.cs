using Glass.Data;
using RestSharp;
using System;
using System.Windows;
using System.Windows.Controls;
using Usuario = Glass.Data.Dto.Usuario;

namespace Glass
{
    /// <summary>
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Page
    {
        private MainWindow Window { get; }
        public InicioSesion(MainWindow w)
        {
            Window = w;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = Window.Contexto.Data<Usuario.Auth>(
                "usuario/autenticacion",
                Method.POST,
                new {
                    rut = txtRut.Text,
                    password = txtPass.Password
                });

            Window.Sesion.Token = data.Token;
        }
    }
}
