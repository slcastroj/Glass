using Glass.Data;
using Glass.Views;
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
            Int32 rol = 0;

            if(Window.IsMock)
            {
                rol = Window.RolMock;
            }
            else
            {
                var data = Window.Contexto.Data<Usuario.Auth>(
                "usuario/autenticacion",
                Method.POST,
                new
                {
                    rut = txtRut.Text,
                    password = txtPass.Password
                });

                Window.Sesion.Token = data.Token;

                rol = Window.Contexto.Data<Usuario.Get>($"usuario/{data.Rut}").Rol;
                Window.Sesion.Rol = rol;
            }

            if(rol == 2) { Window.NavFrame.Navigate(new MenuFarmaceutico(Window)); }
        }
    }
}
