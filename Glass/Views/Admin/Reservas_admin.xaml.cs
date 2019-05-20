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

using EstadoCompra = Glass.Data.Dto.EstadoCompra;
using Reserva = Glass.Data.Dto.Reserva;

namespace Glass.Views.Admin
{
    /// <summary>
    /// Lógica de interacción para Reservas_farm.xaml
    /// </summary>
    public partial class Reservas_admin : Page
    {
		private MainWindow Window { get; }

		public Reservas_admin(MainWindow w)
		{
			Window = w;
			InitializeComponent();

			var estados = Window.Contexto.Data<List<EstadoCompra.Get>>("estadocompra");

			cbEstadoGet.ItemsSource = estados;

			Button_Click(this, null);
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.GoBack();
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			var rq = Window.Contexto.Request("reserva");

			rq.AddParameter("usuario", tbUsuarioGet.Text);
			rq.AddParameter("producto", tbProductoGet.Text);
			rq.AddParameter("estado", ((EstadoCompra.Get)cbEstadoGet.SelectedItem)?.Id);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");

			var reservas = Window.Contexto.Response<List<Reserva.Get>>(rq).Data;
			gridReservas.ItemsSource = reservas;
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			var res = (Reserva.Get)gridReservas.SelectedItem;
			if (res == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var rq = Window.Contexto.Request($"reserva/{res.Id}", Method.DELETE);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}
	}
}
