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

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
			Int32 rol;
			if (Window.IsMock)
            {
                rol = Window.RolMock;
            }
            else
            {
				Usuario.Auth data = Window.Contexto.Data<Usuario.Auth>(
                "usuario/autenticacion",
                Method.POST,
                new
                {
                    rut = txtRut.Text,
                    password = txtPass.Password
                });

                Window.Sesion.Token = data.Token;

				IRestRequest rq = Window.Contexto.Request($"usuario/{data.Rut}");
				rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
				rol = Window.Contexto.Response<Usuario.Get>(rq).Data.Rol;
                Window.Sesion.Rol = rol;
            }

            if(rol == 1) { Window.NavFrame.Navigate(new MenuFarmaceutico(Window)); }
			else if(rol == 2) { Window.NavFrame.Navigate(new MenuAdministrador(Window)); }
        }
    }
}
