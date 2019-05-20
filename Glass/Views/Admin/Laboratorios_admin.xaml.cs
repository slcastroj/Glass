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
		}

		private void Button_Click_4(Object sender, RoutedEventArgs e)
		{
			Window.NavFrame.GoBack();
		}
	}
}
