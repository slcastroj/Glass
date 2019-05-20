using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Usuario = Glass.Data.Dto.Usuario;

namespace Glass.Views.Farmaceutico
{
	/// <summary>
	/// Lógica de interacción para Usuarios_farm.xaml
	/// </summary>
	public partial class Usuarios_farm : Page
	{
		private MainWindow Window { get; }

		public Usuarios_farm(MainWindow w)
		{
			Window = w;
			InitializeComponent();

			Button_Click(this, null);
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			var rq = Window.Contexto.Request("usuario");
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			var usuarios = Window.Contexto.Response<List<Usuario.Get>>(rq).Data;

			if (!String.IsNullOrEmpty(tbRutGet.Text))
			{
				usuarios = usuarios
					.Where(x => x.Rut.Equals(tbRutGet.Text))
					.ToList();
			}

			gridUsuarios.ItemsSource = usuarios;
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			var usuario = new
			{
				rut = tbRutPost.Text,
				nombre = tbNombrePost.Text,
				email = tbEmailPost.Text,
				password = pbPasswordPost.Password,
				fecha_nacimiento = dpFechaPost.DisplayDate.ToString("yyyy-MM-dd"),
				rol = 1
			};

			var rq = Window.Contexto.Request("usuario", Method.POST, usuario);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_2(Object sender, RoutedEventArgs e)
		{
			var u = (Usuario.Get)gridUsuarios.SelectedItem;
			if (u == null)
			{
				MessageBox.Show("Seleccione un usuario");
				return;
			}

			var usuario = new
			{
				email = tbEmailPatch.Text,
				password = tbPassPatch.Password,
				fecha_nacimiento = dpFechaPatch.SelectedDate?.ToString("yyyy-MM-dd")
			};

			var rq = Window.Contexto.Request($"usuario/{u.Rut}", Method.PATCH, usuario);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_3(Object sender, RoutedEventArgs e)
		{
			var u = (Usuario.Get)gridUsuarios.SelectedItem;
			if (u == null)
			{
				MessageBox.Show("Seleccione un usuario");
				return;
			}

			var rq = Window.Contexto.Request($"usuario/{u.Rut}", Method.DELETE);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.GoBack();
		}
	}
}
