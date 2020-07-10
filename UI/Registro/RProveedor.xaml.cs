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
  
    public partial class RProveedor : Window
    {
        public RProveedor()
        {
            InitializeComponent();
            IDProveedorTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ProveedorTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CiudadTextBox.Text = string.Empty;
            TelefonoTextbox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;


        }

        private Proveedores LlenaClases()
        {
            Proveedores proveedores = new Proveedores();
            if (string.IsNullOrWhiteSpace(IDProveedorTextBox.Text))
            {
                IDProveedorTextBox.Text = "0";
            }
            else proveedores.IdProveedor = Convert.ToInt32(IDProveedorTextBox.Text);
            proveedores.Proveëdor = ProveedorTextBox.Text;
            proveedores.Direccion = DireccionTextBox.Text;
            proveedores.Ciudad = CiudadTextBox.Text;
            proveedores.Telefono = TelefonoTextbox.Text;
            proveedores.Email = EmailTextBox.Text;
            return proveedores;
        }


        private void LlenaCampos(Proveedores proveedores)
        {
            IDProveedorTextBox.Text = Convert.ToString(proveedores.IdProveedor);
            ProveedorTextBox.Text = proveedores.Proveëdor;
            DireccionTextBox.Text = proveedores.Direccion;
            CiudadTextBox.Text = proveedores.Ciudad;
            TelefonoTextbox.Text = proveedores.Telefono;
            EmailTextBox.Text = proveedores.Email;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Proveedores proveedores;
            bool paso = false;


            proveedores = LlenaClases();

            if (string.IsNullOrWhiteSpace(IDProveedorTextBox.Text) || IDProveedorTextBox.Text == "0")
                paso = ProveedorBll.Guardar(proveedores);
            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ProveedorBll.Modificar(proveedores);
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
            Proveedores proveedores = ProveedorBll.Buscar(Convert.ToInt32(IDProveedorTextBox.Text));

            return (proveedores != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Proveedores proveedores = new Proveedores();
            int.TryParse(IDProveedorTextBox.Text, out id);

            Limpiar();

            proveedores = ProveedorBll.Buscar(id);

            if (proveedores != null)
            {

                LlenaCampos(proveedores);
            }
            else
            {
                System.Windows.MessageBox.Show("No Encontrada");

            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IDProveedorTextBox.Text);

            Limpiar();

            if (ProveedorBll.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IDProveedorTextBox.Text, "No se puede eliminar porque no existe");
        }
    }
    
}
