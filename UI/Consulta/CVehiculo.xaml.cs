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
    
    public partial class CVehiculo : Window
    {
        public CVehiculo()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Vehiculos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = VehiculoBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = VehiculoBll.GetList(p => p.IdVehiculo == id);
                        break;
                    case 2://Maricula
                        listado = VehiculoBll.GetList(p => p.Matricula.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Marca
                        listado = VehiculoBll.GetList(p => p.Marca.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Modelo
                        listado = VehiculoBll.GetList(p => p.Modelo.Contains(CriterioTextBox.Text));
                        break;


                }

            }
            else
            {
                listado = VehiculoBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    }
}
