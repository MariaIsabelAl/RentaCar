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
using Renta_Car.UI.Registro;

namespace Renta_Car.UI.Registro
{
    
    public partial class RAlquilar : Window
    {
        
        public RAlquilar()
        {
            InitializeComponent();
            IDTextBox.Text = "0";
        }

        private void Limpiar()
        {
            MatriculaTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            FechaE.Text = Convert.ToString(DateTime.Now);
            DuracionTextbox.Text = "0";
            PrecioTextBox.Text = "0";
            TotalTextbox.Text = "0";
            ObservarTextbox.Text = string.Empty;
        }

        private Alquileres LlenaClases()
        {
           
            Alquileres alquileres = new Alquileres();
            if (string.IsNullOrWhiteSpace(IDTextBox.Text))
            {
                IDTextBox.Text = "0";
            }
            else alquileres.IdAlquilar= Convert.ToInt32(IDTextBox.Text);
            alquileres.Matricula = MatriculaTextBox.Text;
            alquileres.NombreCliente = NombreTextBox.Text;
            alquileres.Telefono = TelefonoTextBox.Text;
            alquileres.Cedula = CedulaTextBox.Text;
            alquileres.FechaEntrada = Convert.ToDateTime(FechaE.SelectedDate);
            alquileres.Duracion = Convert.ToDecimal(DuracionTextbox.Text);
            alquileres.PrecioDiario = Convert.ToDecimal(PrecioTextBox.Text);
            alquileres.Total = Convert.ToDecimal(Calcular());
            alquileres.Observacion = ObservarTextbox.Text;
            return alquileres;
        }


        private void LlenaCampos(Alquileres alquileres)
        {
            IDTextBox.Text = Convert.ToString(alquileres.IdAlquilar);
            MatriculaTextBox.Text = alquileres.Matricula;
            NombreTextBox.Text = alquileres.NombreCliente;
            TelefonoTextBox.Text = alquileres.Telefono;
            CedulaTextBox.Text = alquileres.Cedula;
            FechaE.SelectedDate = alquileres.FechaEntrada;
            DuracionTextbox.Text = Convert.ToString(alquileres.Duracion);
            PrecioTextBox.Text = Convert.ToString(alquileres.PrecioDiario);
            TotalTextbox.Text = Convert.ToString(Calcular());
            ObservarTextbox.Text=alquileres.Observacion;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Alquileres alquileres;
            bool paso = false;


            alquileres = LlenaClases();

            if (string.IsNullOrWhiteSpace(IDTextBox.Text) || IDTextBox.Text == "0")
                paso = AlquilarBll.Guardar(alquileres);
            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = AlquilarBll.Modificar(alquileres);
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
            Alquileres alquileres = AlquilarBll.Buscar(Convert.ToInt32(IDTextBox.Text));

            return (alquileres != null);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IDTextBox.Text);

            Limpiar();

            if (AlquilarBll.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IDTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Alquileres alquileres = new Alquileres();
            int.TryParse(IDTextBox.Text, out id);

            Limpiar();

            alquileres = AlquilarBll.Buscar(id);

            if (alquileres != null)
            {
                
                LlenaCampos(alquileres);
            }
            else
            {
                System.Windows.MessageBox.Show("No Encontrada");
            }
        }

        private decimal Calcular()
        {
            decimal valor, duracion, precio;
            
            if (string.IsNullOrWhiteSpace(DuracionTextbox.Text) || DuracionTextbox.Text == "0")
            {
               DuracionTextbox.Text = "0";
            }
            else duracion = Convert.ToDecimal(DuracionTextbox.Text);
            if (string.IsNullOrWhiteSpace(PrecioTextBox.Text) || PrecioTextBox.Text == "0")
            {
                PrecioTextBox.Text = "0";
            }
            else precio = Convert.ToDecimal(PrecioTextBox.Text);
            valor = Convert.ToDecimal(DuracionTextbox.Text) * Convert.ToDecimal(PrecioTextBox.Text);
            TotalTextbox.Text = Convert.ToString(valor);

            return valor;
        }

        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

        private void DuracionTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

       
    }
}
