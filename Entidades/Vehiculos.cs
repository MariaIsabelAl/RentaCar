using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Renta_Car.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioDiario { get; set; }
        public int IdProveedor { get; set; }

        public Vehiculos()
        {
            IdVehiculo = 0;
            Matricula = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            FechaCompra = DateTime.Now;
            PrecioDiario = 0;
            IdProveedor = 0;
        }
    }
}
