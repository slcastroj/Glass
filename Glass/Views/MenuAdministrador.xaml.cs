using Glass.Views.Admin;
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

namespace Glass.Views
{
    /// <summary>
    /// Lógica de interacción para MenuFarmaceutico.xaml
    /// </summary>
    public partial class MenuAdministrador : Page
    {
        private MainWindow Window { get; }
        public MenuAdministrador(MainWindow w)
        {
            Window = w;
            InitializeComponent();
        }

		private void Button_Click(Object sender, RoutedEventArgs e)
		{
			Window.Sesion.Clear();
			Window.NavFrame.GoBack();
		}

		private void Button_Click_1(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.Navigate(new Productos_admin(Window));
		}

		private void Button_Click_2(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.Navigate(new Usuarios_admin(Window));
		}

		private void Button_Click_3(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.Navigate(new Reservas_admin(Window));
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.Navigate(new Laboratorios_admin(Window));
		}

		private void Button_Click_5(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.Navigate(new Compras_admin(Window));
		}
	}
}
