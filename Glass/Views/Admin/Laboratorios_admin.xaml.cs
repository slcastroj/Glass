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

using Laboratorio = Glass.Data.Dto.Laboratorio;

namespace Glass.Views.Admin
{
	/// <summary>
	/// Lógica de interacción para Laboratorios_admin.xaml
	/// </summary>
	public partial class Laboratorios_admin : Page
	{
		private MainWindow Window { get; }
		public Laboratorios_admin(MainWindow w)
		{
			Window = w;
			InitializeComponent();

			Buscar();
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.GoBack();
		}

		public void Buscar()
		{
			var rq = Window.Contexto.Request("laboratorio");

			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");

			var reservas = Window.Contexto.Response<List<Laboratorio.Get>>(rq).Data;
			gridLabs.ItemsSource = reservas;
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			var lab = new
			{
				nombre = tbNombre.Text
			};

			var rq = Window.Contexto.Request("laboratorio", Method.POST, lab);

			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");

			Window.Contexto.Response<Object>(rq);

			Buscar();
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			var lab = (Laboratorio.Get)gridLabs.SelectedItem;
			if (lab == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var rq = Window.Contexto.Request($"laboratorio/{lab.Id}", Method.DELETE);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Buscar();
		}
	}
}
