using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Renta_Car.Entidades;
using Renta_Car.RentaBll;
using System.Data;
using System.Linq;

namespace Renta_Car.UI.Consulta
{
    public partial class CProveedor : Window
    {
        public CProveedor()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proveedores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ProveedorBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ProveedorBll.GetList(p => p.IdProveedor == id);
                        break;
                    case 2://Proveedor
                        listado = ProveedorBll.GetList(p => p.Proveëdor.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Direccion
                        listado = ProveedorBll.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Ciudad
                        listado = ProveedorBll.GetList(p => p.Ciudad.Contains(CriterioTextBox.Text));
                        break;


                }

            }
            else
            {
                listado = ProveedorBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    }
    
}
