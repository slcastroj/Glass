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

using EstadoCompra = Glass.Data.Dto.EstadoCompra;
using Reserva = Glass.Data.Dto.Reserva;
using Compra = Glass.Data.Dto.Compra;
using RestSharp;

namespace Glass.Views.Admin
{
	/// <summary>
	/// Lógica de interacción para Compras_admin.xaml
	/// </summary>
	public partial class Compras_admin : Page
	{
		private MainWindow Window { get; }
		public Compras_admin(MainWindow w)
		{
			Window = w;
			InitializeComponent();

			var estados = Window.Contexto.Data<List<EstadoCompra.Get>>("estadocompra");

			cbEstadoGet.ItemsSource = estados;
			cbEstado.ItemsSource = estados;

			Button_Click(this, null);
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.GoBack();
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			var estados = Window.Contexto.Data<List<EstadoCompra.Get>>("estadocompra");
			var rq = Window.Contexto.Request("compra");

			rq.AddParameter("usuario", tbUsuarioGet.Text);
			rq.AddParameter("producto", tbProductoGet.Text);
			rq.AddParameter("estado", ((EstadoCompra.Get)cbEstadoGet.SelectedItem)?.Id);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");

			var compras = Window.Contexto.Response<List<Compra.Get>>(rq).Data;
			gridCompras.ItemsSource = compras.Select(x => new {
				x.Id,
				Estado = estados.Find(y => y.Id == x.Estado).Nombre,
				Reserva = x.Reserva.Id,
				x.Reserva.Usuario
			});
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			var compra = (dynamic)gridCompras.SelectedItem;
			if (compra == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var rq = Window.Contexto.Request(
				$"compra/{compra.Id}",
				Method.PATCH,
				new { estado = ((EstadoCompra.Get)cbEstado.SelectedItem).Id }
				);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_2(Object sender, RoutedEventArgs e)
		{
			var compra = (Compra.Get)gridCompras.SelectedItem;
			if (compra == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var rq = Window.Contexto.Request($"compra/{compra.Id}", Method.DELETE);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}
	}
}
