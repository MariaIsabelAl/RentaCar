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
    
    public partial class CAlquliar : Window
    {
        public CAlquliar()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Alquileres>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = AlquilarBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = AlquilarBll.GetList(p => p.IdAlquilar == id);
                        break;
                    case 2://Nombre
                        listado = AlquilarBll.GetList(p => p.NombreCliente.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Cedula
                        listado = AlquilarBll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Matricula
                        listado = AlquilarBll.GetList(p => p.Matricula.Contains(CriterioTextBox.Text));
                        break;


                }

            }
            else
            {
                listado = AlquilarBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    }
    
}
