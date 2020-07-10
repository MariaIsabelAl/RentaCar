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
using Renta_Car.RentaBll;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Renta_Car.Entidades;
using Renta_Car.DAL;

namespace Renta_Car.UI.Registro
{
   
    public partial class RVehiculo : Window
    {
        public RVehiculo()
        {
            InitializeComponent();
            IDVehiculoTextBox.Text = "0";
        }

        private void Limpiar()
        {
            MatriculaTextBox.Text = string.Empty;
            MarcaTextBox.Text = string.Empty;
            ModeloTextBox.Text = string.Empty;
            FechaCompra.Text = Convert.ToString(DateTime.Now);
            PrecioTextbox.Text = "0";
            IdProveedorTextBox.Text = "0";
            
        }

        private Vehiculos LlenaClases()
        {
            Vehiculos vehiculos = new Vehiculos();
            if (string.IsNullOrWhiteSpace(IDVehiculoTextBox.Text))
            {
                IDVehiculoTextBox.Text = "0";
            }
            else vehiculos.IdVehiculo = Convert.ToInt32(IDVehiculoTextBox.Text);
            vehiculos.Matricula = MatriculaTextBox.Text;
            vehiculos.Marca = MarcaTextBox.Text;
            vehiculos.Modelo = ModeloTextBox.Text;
            vehiculos.FechaCompra = Convert.ToDateTime(FechaCompra.SelectedDate);
            if (string.IsNullOrWhiteSpace(PrecioTextbox.Text))
            {
                PrecioTextbox.Text = "0";
            }
            else vehiculos.PrecioDiario = Convert.ToDecimal(PrecioTextbox.Text);
            if (string.IsNullOrWhiteSpace(IdProveedorTextBox.Text))
            {
                IdProveedorTextBox.Text = "0";
            }
            else vehiculos.IdProveedor = Convert.ToInt32(IdProveedorTextBox.Text);
            return vehiculos;
        }


        private void LlenaCampos(Vehiculos vehiculos)
        {
            IDVehiculoTextBox.Text = Convert.ToString(vehiculos.IdVehiculo);
            MatriculaTextBox.Text = vehiculos.Matricula;
            MarcaTextBox.Text = vehiculos.Marca;
            ModeloTextBox.Text = vehiculos.Modelo;
            FechaCompra.SelectedDate = vehiculos.FechaCompra;
            PrecioTextbox.Text = Convert.ToString(vehiculos.PrecioDiario);
            IdProveedorTextBox.Text = Convert.ToString(vehiculos.IdProveedor);          
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos vehiculos;
            bool paso = false;


            vehiculos = LlenaClases();

            if (string.IsNullOrWhiteSpace(IDVehiculoTextBox.Text) || IDVehiculoTextBox.Text == "0")
                paso = VehiculoBll.Guardar(vehiculos);
            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = VehiculoBll.Modificar(vehiculos);
            }

            if (paso)
            {
                Limpiar();
                System.Windows.MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ExisteBD()
        {
            Vehiculos vehiculos = VehiculoBll.Buscar(Convert.ToInt32(IDVehiculoTextBox.Text));

            return (vehiculos != null);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IDVehiculoTextBox.Text);

            Limpiar();

            if (VehiculoBll.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IDVehiculoTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Vehiculos vehiculos = new Vehiculos();
            int.TryParse(IDVehiculoTextBox.Text, out id);

            Limpiar();

            vehiculos = VehiculoBll.Buscar(id);

            if (vehiculos != null)
            {
                
                LlenaCampos(vehiculos);
            }
            else
            {
                System.Windows.MessageBox.Show("No Encontrada");
                
            }
        }
    }
}
