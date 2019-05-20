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
	}
}
