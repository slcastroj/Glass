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

using Producto = Glass.Data.Dto.Producto;
using TipoProducto = Glass.Data.Dto.TipoProducto;
using Laboratorio = Glass.Data.Dto.Laboratorio;
using RestSharp;

namespace Glass.Views.Admin
{
	/// <summary>
	/// Lógica de interacción para Productos_farm.xaml
	/// </summary>
	public partial class Productos_admin : Page
	{
		private MainWindow Window { get; }

		public Productos_admin(MainWindow w)
		{
			Window = w;
			InitializeComponent();

			var tipos = Window.Contexto.Data<List<TipoProducto.Get>>("tipoproducto");
			var labs = Window.Contexto.Data<List<Laboratorio.Get>>("laboratorio");

			cbTipo.ItemsSource = tipos;
			cbTipoPost.ItemsSource = tipos;
			cbTipoPut.ItemsSource = tipos;

			cbLab.ItemsSource = labs;
			cbLabPost.ItemsSource = labs;
			cbLabPut.ItemsSource = labs;

			Button_Click(this, null);
		}

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			IRestRequest rq = Window.Contexto.Request("producto");

			if (cbTipo.SelectedIndex != -1)
			{
				rq.AddParameter("tipo", ((TipoProducto.Get)cbTipo.SelectedItem).Id);
			}
			if (cbLab.SelectedIndex != -1)
			{
				rq.AddParameter("laboratorio", ((Laboratorio.Get)cbLab.SelectedItem).Id);
			}

			if (chkStock.IsChecked.HasValue)
			{
				rq.AddParameter("tiene_stock", chkStock.IsChecked.Value);
			}

			if (!String.IsNullOrEmpty(tbNombre.Text))
			{
				rq.AddParameter("nombre", tbNombre.Text);
			}

			gridProd.ItemsSource = Window.Contexto.Response<List<Producto.Get>>(rq).Data;
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			var producto = new
			{
				nombre = tbNombrePost.Text,
				necesita_receta = chkRecetaPost.IsChecked.Value,
				descripcion = tbDescPost.Text,
				stock = tbStockPost.Text,
				peso_gr = tbPesoPost.Text,
				precio_unidad = tbPrecioPost.Text,
				maximo_semanal = tbMaxPost.Text,
				laboratorio = ((Laboratorio.Get)cbLabPost.SelectedItem).Id,
				tipo = ((TipoProducto.Get)cbTipoPost.SelectedItem).Id,
			};

			var rq = Window.Contexto.Request("producto", Method.POST, producto);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_2(Object sender, RoutedEventArgs e)
		{
			var prod = (Producto.Get)gridProd.SelectedItem;
			if (prod == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var producto = new
			{
				nombre = tbNombrePut.Text,
				necesita_receta = chkRecetaPut.IsChecked.Value,
				descripcion = tbDescPut.Text,
				stock = tbStockPut.Text,
				peso_gr = tbPesoPut.Text,
				precio_unidad = tbPrecioPut.Text,
				maximo_semanal = tbMaxPut.Text,
				laboratorio = ((Laboratorio.Get)cbLabPut.SelectedItem).Id,
				tipo = ((TipoProducto.Get)cbTipoPut.SelectedItem).Id,
			};

			var rq = Window.Contexto.Request($"producto/{prod.Id}", Method.PUT, producto);
			rq.AddHeader("Authorization", $"Bearer {Window.Sesion.Token}");
			Window.Contexto.Response<Object>(rq);

			Button_Click(this, null);
		}

		private void Button_Click_3(Object sender, RoutedEventArgs e)
		{
			var prod = (Producto.Get)gridProd.SelectedItem;
			if (prod == null)
			{
				MessageBox.Show("Seleccione un elemento de la lista");
				return;
			}

			var rq = Window.Contexto.Request($"producto/{prod.Id}", Method.DELETE);
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
