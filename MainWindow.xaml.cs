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
using Renta_Car.UI.Registro;
using Renta_Car.UI.Consulta;

namespace Renta_Car
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehiculoButton_Click(object sender, RoutedEventArgs e)
        {
            RVehiculo rVehiculo = new RVehiculo();
            rVehiculo.Show();
        }

        private void AlquilarButton_Click(object sender, RoutedEventArgs e)
        {
            RAlquilar rAlquilar = new RAlquilar();
            rAlquilar.Show();
        }

        private void ProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            RProveedor rProveedor = new RProveedor();
            rProveedor.Show();
        }

        private void Consultar2Button_Click(object sender, RoutedEventArgs e)
        {
            CAlquliar cAlquliar = new CAlquliar();
            cAlquliar.Show();
        }

        private void Consultar1Button_Click(object sender, RoutedEventArgs e)
        {
            CProveedor cProveedor = new CProveedor();
            cProveedor.Show();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CVehiculo cVehiculo = new CVehiculo();
            cVehiculo.Show();
        }
    }
}
